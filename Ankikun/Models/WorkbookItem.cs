using System.ComponentModel;
using System.Xml.Serialization;

namespace Ankikun.Models
{
	/// <summary>
	/// ワークブックの問題
	/// </summary>
	public class WorkbookItem
	{
		/// <summary>
		/// 問題文
		/// </summary>
		[DisplayName("問題文")]
		[XmlElement]
		public string Question { get; set; } = "";

		/// <summary>
		/// 答え
		/// </summary>
		[DisplayName("答え")]
		[XmlElement]
		public string Answer { get; set; } = "";

		/// <summary>
		/// タグ(カンマ区切り)
		/// </summary>
		[DisplayName("タグ (カンマ区切り)")]
		[XmlIgnore]
		public string TagsString
		{
			get => string.Join(", ", Tags); // 配列の値をカンマで結合
			set
			{
				Tags = string.IsNullOrWhiteSpace(value) ? 
					Array.Empty<string>() : value.Split(","); // カンマで分割
			}
		}

		/// <summary>
		/// タグ
		/// </summary>
		[XmlArray]
		public string[] Tags
		{
			get => tags;
			set => tags = value
				.Select(x => x.Trim()) // 先頭/末尾の空白を削除
				.Where(y => !string.IsNullOrWhiteSpace(y)) // 空文字列を削除
				.Distinct() // 重複した文字列を削除
				.ToArray();
		}

		/// <summary>
		/// 正解した回数
		/// </summary>
		[DisplayName("正解した回数")]
		[ReadOnly(true)]
		[XmlElement]
		public int ClearedCount { get; set; }

		/// <summary>
		/// 回答した回数
		/// </summary>
		[DisplayName("回答した回数")]
		[ReadOnly(true)]
		[XmlElement]
		public int AnsweredCount { get; set; }

		/// <summary>
		/// 正答率
		/// </summary>
		[DisplayName("正答率 [%]")]
		[ReadOnly(true)]
		[XmlIgnore]
		public int Rate
			=> AnsweredCount > 0 ? 100 * ClearedCount / AnsweredCount : 0;

		/// <summary>
		/// タグ
		/// </summary>
		string[] tags = Array.Empty<string>();

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
	}
}
