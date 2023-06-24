using System.ComponentModel;
using System.Xml.Linq;

namespace Ankikun.Models
{
	/// <summary>
	/// 確認テスト
	/// </summary>
	public class Exam : IXMLObject
	{
		/// <summary>
		/// テスト終了時
		/// </summary>
		public event EventHandler Finished = (sender,e) => { };

		/// <summary>
		/// 確認問題
		/// </summary>
		public ExamItem[] Items { get; }

		/// <summary>
		/// 実施日時
		/// </summary>
		[DisplayName("実施日時")]
		[ReadOnly(true)]
		public DateTime? Date { get; private set; }

		/// <summary>
		/// 正解した問題数
		/// </summary>
		[DisplayName("正解した問題数")]
		[ReadOnly(true)]
		public int Cleared { get; private set; }

		/// <summary>
		/// 回答した問題数
		/// </summary>
		[DisplayName("回答した問題数")]
		[ReadOnly(true)]
		public int Answered { get; private set; }

		/// <summary>
		/// 正答率
		/// </summary>
		[DisplayName("正答率 [%]")]
		[ReadOnly(true)]
		public int Rate => Answered > 0 ? 100 * Cleared / Answered : 0;

		/// <summary>
		/// 厳格採点
		/// </summary>
		[DisplayName("厳格採点")]
		[ReadOnly(true)]
		public bool Strict => config.Strict;

		/// <summary>
		/// 問題と答えの反転
		/// </summary>
		[DisplayName("問題と答えの反転")]
		[ReadOnly(true)]
		public bool Reverse => config.Reverse;

		/// <summary>
		/// 問題のシャッフル
		/// </summary>
		[DisplayName("シャッフルして出題")]
		[ReadOnly(true)]
		public bool Shuffle => config.Shuffle;

		/// <summary>
		/// 正答率が50%未満の問題のみを抽出
		/// </summary>
		[DisplayName("正答率が低い問題のみ")]
		[ReadOnly(true)]
		public bool LowRate => config.LowRate;

		/// <summary>
		/// 指定したタグのみを抽出
		/// </summary>
		[DisplayName("タグ指定")]
		[ReadOnly(true)]
		public string Tag => config.Tag;

		[Browsable(false)]
		public bool IsEmpty => Date == null || Answered == 0;

		/// <summary>
		/// 条件設定
		/// </summary>
		ExamConfig config;

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		/// <param name="wbItems">全ての問題</param>\
		/// <param name="config">条件設定</param>
		public Exam(IEnumerable<WorkbookItem> wbItems, ExamConfig config)
		{
			// 確認問題の作成
			IEnumerable<ExamItem> items = wbItems
				.Where(x => !config.LowRate || x.Rate < 50)
				.Where(y => string.IsNullOrWhiteSpace(config.Tag)
					|| y.Tags.Contains(config.Tag))
				.Select(z => new ExamItem(z, config.Reverse));

			// 確認問題のシャッフル
			if (config.Shuffle) items = items.OrderBy(x => Guid.NewGuid());

			this.config = config;
			Date = null;
			Items = items.ToArray();
		}

		/// <summary>
		/// 初期化(コンストラクタ，XMLデシリアライズ)
		/// </summary>
		/// <param name="root">XElement オブジェクト</param>
		public Exam(XElement root)
		{
			// XML要素の値の取得
			string date = IXMLObject.GetValue(root, nameof(Date));
			string cleared = IXMLObject.GetValue(root, nameof(Cleared));
			string answered = IXMLObject.GetValue(root, nameof(Answered));

			// 条件設定
			XElement? config = root.Element("Config");
			if (config != null) this.config = new(config);

			// 日時型の代入
			try
			{
				Date = DateTime.Parse(date);
			}
			catch
			{
				Date = null;
			}

			// 数値の代入
			try
			{
				SetQuestionsCount(int.Parse(cleared), int.Parse(answered));
			}
			catch
			{
				Cleared = Answered = 0;
			}

			Items = Array.Empty<ExamItem>();
		}

		public XElement? Serialize() => Serialize(nameof(Exam));

		public XElement? Serialize(string name)
		{
			if (IsEmpty) return null;

			return new (name,
				new XElement(nameof(Date), Date),
				new XElement(nameof(Cleared), Cleared),
				new XElement(nameof(Answered), Answered),
				new XElement("Config", config.Serialize())
			);
		}

		void SetQuestionsCount(int cleared, int answered)
		{
			bool error = cleared < 0 || answered < 0 || cleared > answered;
			Cleared = error ? 0 : cleared;
			Answered = error ? 0 : answered;
		}

		public void Finish()
		{
			// 各問題別の正解/回答回数を更新
			foreach (ExamItem item in Items) item.UpdateCounter();

			// 正解/回答した問題数の集計
			int cleared = Items.Where(x => x.Result).Count();
			int answered = Items.Where(x => x.Answered).Count();

			// 実施日時の記録
			Date = DateTime.Now;

			// イベント発生
			Finished(this, new());
		}
	}
}
