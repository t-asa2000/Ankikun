using System.Xml.Linq;

namespace Ankikun.Models
{
	/// <summary>
	/// 確認テストの条件設定
	/// </summary>
	public struct ExamConfig : IXMLObject
	{
		/// <summary>
		/// 厳格採点
		/// </summary>
		public bool Strict { get; set; }

		/// <summary>
		/// 問題と答えの反転
		/// </summary>
		public bool Reverse { get; set; }

		/// <summary>
		/// 問題のシャッフル
		/// </summary>
		public bool Shuffle { get; set; }

		/// <summary>
		/// 正答率が50%未満の問題のみを抽出
		/// </summary>
		public bool LowRate { get; set; }

		/// <summary>
		/// 指定したタグのみを抽出
		/// </summary>
		public string Tag { get; set; }

		public ExamConfig(XElement root)
		{
			// XML要素の値を取得
			string strict = IXMLObject.GetValue(root, nameof(Strict));
			string reverse = IXMLObject.GetValue(root, nameof(Reverse));
			string shuffle = IXMLObject.GetValue(root, nameof(Shuffle));
			string lowrate = IXMLObject.GetValue(root, nameof(LowRate));
			Tag = IXMLObject.GetValue(root, nameof(Tag));

			// 論理値の代入
			try
			{
				Strict = bool.Parse(strict);
				Reverse = bool.Parse(reverse);
				Shuffle = bool.Parse(shuffle);
				LowRate = bool.Parse(lowrate);
			}
			catch
			{
				Strict = Reverse = Shuffle = LowRate = false;
			}
		}

		public bool IsEmpty => false;

		public XElement Serialize() => Serialize(nameof(ExamConfig));

		public XElement Serialize(string name)
			=> new(name,
				new XElement(nameof(Strict), Strict),
				new XElement(nameof(Reverse), Reverse),
				new XElement(nameof(Shuffle), Shuffle),
				new XElement(nameof(LowRate), LowRate),
				new XElement(nameof(Tag), Tag)
			);
	}
}
