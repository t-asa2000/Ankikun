using System.Xml.Serialization;

namespace Ankikun.Models
{
	/// <summary>
	/// 確認テストの条件設定
	/// </summary>
	public struct ExamConfig
	{
		/// <summary>
		/// 厳格採点
		/// </summary>
		[XmlElement]
		public bool Strict { get; set; } = false;

		/// <summary>
		/// 問題と答えの反転
		/// </summary>
		[XmlElement]
		public bool Reverse { get; set; } = false;

		/// <summary>
		/// 問題のシャッフル
		/// </summary>
		[XmlElement]
		public bool Shuffle { get; set; } = false;

		/// <summary>
		/// 正答率が50%未満の問題のみを抽出
		/// </summary>
		[XmlElement]
		public bool LowRate { get; set; } = false;

		/// <summary>
		/// 指定したタグのみを抽出
		/// </summary>
		[XmlElement]
		public string Tag { get; set; } = "";

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		public ExamConfig() { }
	}
}
