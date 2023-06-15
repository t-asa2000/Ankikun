using Ankikun.Models.Interfaces;
using System.Xml.Linq;

namespace Ankikun.Models
{
	/// <summary>
	/// WorkbookをXML形式で読み込み・保存するためのクラス
	/// </summary>
	public class WorkbookXMLConverter : IXMLConverter<Workbook>
	{
		/// <summary>
		/// 最新のXMLファイルバージョン(アプリデータ バージョン)
		/// </summary>
		public const int LatestVersion = 1;

		/// <summary>
		/// Workbook オブジェクト
		/// </summary>
		Workbook? version1 = null;

		/// <summary>
		/// オブジェクトを登録
		/// </summary>
		/// <param name="obj">Workbook オブジェクト</param>
		public void SetObject(Workbook obj)
		{
			version1 = obj;
		}

		/// <summary>
		/// オブジェクトを取得
		/// </summary>
		/// <returns>Workbook オブジェクト</returns>
		public Workbook? GetObject()
		{
			return version1;
		}

		/// <summary>
		/// XMLファイルから読み込み
		/// </summary>
		/// <param name="path">ファイルパス</param>
		public void Load(string path)
		{
			try
			{
				// 読み込み
				XElement? root = XDocument.Load(path)?.Root;
				if (root != null) Deserialize(root);
			}
			catch
			{

			}

		}

		/// <summary>
		/// XMLファイルに保存
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>成功すればtrue</returns>
		public bool Save(string path)
		{
			XElement? root = Serialize();
			if (root == null) return false;

			try
			{
				// フォルダーを作成
				Directory.GetParent(path)?.Create();
				
				// 出力
				new XDocument(root).Save(path);

				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <returns>XElement オブジェクト</returns>
		XElement? Serialize()
		{
			XElement root = new(nameof(WorkbookXMLConverter));
			XElement? v1 = version1?.Serialize(nameof(version1));

			if (v1 != null) root.Add(v1);

			return root.Elements().Count() > 0 ? root : null;
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="root">XElement オブジェクト</param>
		void Deserialize(XElement root)
		{
			XElement? v1 = root.Element(nameof(version1));

			if (v1 != null)
			{
				version1 = new(v1);
				if (version1.IsEmpty) version1 = null;
			}
		}
	}
}
