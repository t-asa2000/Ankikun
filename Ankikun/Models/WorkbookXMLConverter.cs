using System.Xml.Linq;

namespace Ankikun.Models
{
    /// <summary>
    /// WorkbookをXML形式で読み込み・保存するためのクラス
    /// </summary>
    public class WorkbookXMLConverter : XMLConverter<Workbook>
	{
		/// <summary>
		/// 最新のXMLファイルバージョン(アプリデータ バージョン)
		/// </summary>
		public const int LatestVersion = 1;

		/// <summary>
		/// 要素名(v1)
		/// </summary>
		const string version1 = nameof(version1);

		/// <summary>
		/// オブジェクトを取得
		/// </summary>
		/// <returns>Workbook オブジェクト</returns>
		protected override Workbook? GetObject()
		{
			Workbook? obj = null;
			XElement? v1 = Root?.Element(version1);

			if (v1 != null) obj ??= new(v1);

			return (obj?.IsEmpty ?? true) ? null : obj;
		}

		/// <summary>
		/// オブジェクトの設定
		/// </summary>
		/// <param name="obj">Workbook オブジェクト</param>
		protected override void SetObject(Workbook obj)
		{
			Root = new(nameof(WorkbookXMLConverter));
			Root.Add(obj.Serialize(version1));
		}
	}
}
