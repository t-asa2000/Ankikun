using Ankikun.Models.Interfaces;
using System.ComponentModel;
using System.Xml.Linq;

namespace Ankikun.Models
{
	/// <summary>
	/// 問題集(ワークブック)
	/// </summary>
	public class Workbook : IXMLObject
	{
		/// <summary>
		/// 問題
		/// </summary>
		public BindingList<WorkbookItem> Items { get; }

		/// <summary>
		/// 確認テストの履歴
		/// </summary>
		public BindingList<Exam> Histories { get; }

		public bool IsEmpty => Items.Count + Histories.Count == 0;

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		public Workbook()
		{
			Items = new();
			Histories = new();
		}

		/// <summary>
		/// 初期化(コンストラクタ，XMLデシリアライズ)
		/// </summary>
		/// <param name="root">XElement オブジェクト</param>
		public Workbook(XElement root)
		{
			List<WorkbookItem> items = root.Element(nameof(Items))?.Elements()
				.Select(x => new WorkbookItem(x))
				.Where(y => !y.IsEmpty)
				.ToList() ?? new();
			List<Exam> histories = root.Element(nameof(Histories))?.Elements()
				.Select(x => new Exam(x))
				.Where(y => !y.IsEmpty)
				.ToList() ?? new();

			Items = new(items);
			Histories = new(histories);
		}

		public XElement Serialize() => Serialize(nameof(Workbook));

		public XElement Serialize(string name)
			=> new (name,
				new XElement(nameof(Items), IXMLObject.Serialize(Items)),
				new XElement(nameof(Histories), IXMLObject.Serialize(Histories))
			);

		/// <summary>
		/// 確認テストの開始
		/// </summary>
		/// <param name="config">条件設定</param>
		/// <returns>確認テスト</returns>
		public Exam? StartExam(ExamConfig config)
		{
			// 確認テストの作成
			Exam exam = new(Items, config);

			// 問題数が0の場合はnullを返す
			if (exam.Items.Length == 0) return null;

			// 終了したら履歴に追加
			exam.Finished += (sender, e) =>
			{
				if (!exam.IsEmpty) Histories.Insert(0, exam);
			};

			return exam;
		}

		/// <summary>
		/// XMLファイルを保存
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>成功したらtrue</returns>
		public bool SaveXML(string path)
		{
			WorkbookXMLConverter converter = new();
			converter.SetObject(this);
			return converter.Save(path);
		}

		/// <summary>
		/// XMLファイルから読み込み
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>Workbook オブジェクト</returns>
		public static Workbook? LoadXML(string path)
		{
			WorkbookXMLConverter converter = new();
			converter.Load(path);
			return converter.GetObject();
		}
	}
}
