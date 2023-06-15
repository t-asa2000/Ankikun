using Ankikun.Models.Interfaces;
using System.ComponentModel;
using System.Xml.Linq;

namespace Ankikun.Models
{
	/// <summary>
	/// ワークブックの問題
	/// </summary>
	public class WorkbookItem : IXMLObject
	{
		/// <summary>
		/// 問題文
		/// </summary>
		[DisplayName("問題文")]
		public string Question { get; set; }

		/// <summary>
		/// 答え
		/// </summary>
		[DisplayName("答え")]
		public string Answer { get; set; }

		/// <summary>
		/// タグ(カンマ区切り)
		/// </summary>
		[DisplayName("タグ (カンマ区切り)")]
		public string TagsString
		{
			get => string.Join(", ", Tags); // 配列の値をカンマで結合
			set => Tags = RemoveDuplicatedTags((value ?? "").Split(","));
		}

		/// <summary>
		/// タグ
		/// </summary>
		public string[] Tags { get; private set; }

		/// <summary>
		/// 正解した回数
		/// </summary>
		[DisplayName("正解した回数")]
		[ReadOnly(true)]
		public int ClearedCount { get; private set; }

		/// <summary>
		/// 回答した回数
		/// </summary>
		[DisplayName("回答した回数")]
		[ReadOnly(true)]
		public int AnsweredCount { get; private set; }

		/// <summary>
		/// 正答率
		/// </summary>
		[DisplayName("正答率 [%]")]
		[ReadOnly(true)]
		public int Rate
			=> AnsweredCount > 0 ? 100 * ClearedCount / AnsweredCount : 0;

		/// <summary>
		/// データが空かどうか
		/// </summary>
		/// <returns>空であればtrue</returns>
		[Browsable(false)]
		public bool IsEmpty
			=> string.IsNullOrWhiteSpace(Question)
				&& string.IsNullOrWhiteSpace(Answer);

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		public WorkbookItem()
		{
			Question = "";
			Answer = "";
			Tags = Array.Empty<string>();
		}

		/// <summary>
		/// 初期化(コンストラクタ，XMLデシリアライズ)
		/// </summary>
		/// <param name="root">XElement オブジェクト</param>
		public WorkbookItem(XElement root)
		{
			// XML要素の値を取得
			Question = IXMLObject.GetValue(root, nameof(Question));
			Answer = IXMLObject.GetValue(root, nameof(Answer));
			string[] tags = IXMLObject.GetChildren(root, nameof(Tags));
			string cleared = IXMLObject.GetValue(root, nameof(ClearedCount));
			string answered = IXMLObject.GetValue(root, nameof(AnsweredCount));

			// タグを設定
			Tags = RemoveDuplicatedTags(tags);

			// 数値を代入
			try
			{
				SetCounter(int.Parse(cleared), int.Parse(answered));
			}
			catch
			{
				ResetCounter();
			}
		}

		/// <summary>
		/// XMLシリアライズ
		/// </summary>
		/// <returns>XElement オブジェクト</returns>
		public XElement? Serialize() => Serialize(nameof(WorkbookItem));

		/// <summary>
		/// XMLシリアライズ
		/// </summary>
		/// <param name="name"></param>
		/// <returns>XElement オブジェクト</returns>
		public XElement? Serialize(string name)
		{
			if (IsEmpty) return null;

			XElement[] tags = Tags.Select(x => new XElement("tag", x)).ToArray();

			return new (name,
				new XElement(nameof(Question), Question),
				new XElement(nameof(Answer), Answer),
				new XElement(nameof(Tags), tags),
				new XElement(nameof(ClearedCount), ClearedCount),
				new XElement(nameof(AnsweredCount), AnsweredCount)
			);
		}

		/// <summary>
		/// カウンターを更新
		/// </summary>
		/// <param name="clear">正解したかどうか</param>
		public void UpdateCounter(bool clear)
		{
			if (clear) ClearedCount++;
			AnsweredCount++;
		}

		/// <summary>
		/// カウンターをリセット
		/// </summary>
		public void ResetCounter() => ClearedCount = AnsweredCount = 0;

		/// <summary>
		/// カウンターの値をセット
		/// </summary>
		void SetCounter(int cleared, int answered)
		{
			bool error = cleared < 0 || answered < 0 || cleared > answered;
			ClearedCount = error ? 0 : cleared;
			AnsweredCount = error ? 0 : answered;
		}

		/// <summary>
		/// 重複したタグを削除
		/// </summary>
		/// <param name="tags">タグ</param>
		/// <returns>重複削除後の配列</returns>
		static string[] RemoveDuplicatedTags(string[] tags)
			=> tags.Select(x => x.Trim()) // 先頭/末尾の空白を削除
				.Where(y => !string.IsNullOrWhiteSpace(y)) // 空文字列を削除
				.Distinct() // 重複した文字列を削除
				.ToArray();
	}
}
