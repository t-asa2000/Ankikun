using System.ComponentModel;
using System.Xml.Serialization;

namespace Ankikun.Models
{
	/// <summary>
	/// 確認テストの履歴
	/// </summary>
	public class ExamHistory
	{
		/// <summary>
		/// 実施日時
		/// </summary>
		[XmlElement]
		[DisplayName("実施日時")]
		[ReadOnly(true)]
		public DateTime Date { get; set; } = DateTime.Now;

		/// <summary>
		/// 正解した問題数
		/// </summary>
		[XmlElement]
		[DisplayName("正解した問題数")]
		[ReadOnly(true)]
		public int Cleared { get; set; }

		/// <summary>
		/// 回答した問題数
		/// </summary>
		[XmlElement]
		[DisplayName("回答した問題数")]
		[ReadOnly(true)]
		public int Answered { get; set; }

		/// <summary>
		/// 正答率
		/// </summary>
		[XmlIgnore]
		[DisplayName("正答率 [%]")]
		[ReadOnly(true)]
		public int Rate => Answered > 0 ? 100 * Cleared / Answered : 0;

		/// <summary>
		/// 厳格採点
		/// </summary>
		[XmlIgnore]
		[DisplayName("厳格採点")]
		[ReadOnly(true)]
		public bool Strict => Config.Strict;

		/// <summary>
		/// 問題と答えの反転
		/// </summary>
		[XmlIgnore]
		[DisplayName("問題と答えの反転")]
		[ReadOnly(true)]
		public bool Reverse => Config.Reverse;

		/// <summary>
		/// 問題のシャッフル
		/// </summary>
		[XmlIgnore]
		[DisplayName("シャッフルして出題")]
		[ReadOnly(true)]
		public bool Shuffle => Config.Shuffle;

		/// <summary>
		/// 正答率が50%未満の問題のみを抽出
		/// </summary>
		[XmlIgnore]
		[DisplayName("正答率が低い問題のみ")]
		[ReadOnly(true)]
		public bool LowRate => Config.LowRate;

		/// <summary>
		/// 指定したタグのみを抽出
		/// </summary>
		[XmlIgnore]
		[DisplayName("タグ指定")]
		[ReadOnly(true)]
		public string Tag => Config.Tag;

		/// <summary>
		/// 条件設定
		/// </summary>
		[XmlElement]
		[Browsable(false)]
		public ExamConfig Config { get; set; }
	}
}
