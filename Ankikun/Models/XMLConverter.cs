using System.Xml.Linq;

namespace Ankikun.Models
{
    /// <summary>
    /// XMLファイルを読み込み・生成する抽象クラス
    /// </summary>
    /// <typeparam name="T">シリアライズしたい型</typeparam>
    public abstract class XMLConverter<T>
    where T : IXMLObject
    {
		/// <summary>
		/// XMLルート要素
		/// </summary>
		protected XElement? Root { get; set; } = null;

        /// <summary>
        /// XMLファイルから読み込み
        /// </summary>
        /// <param name="path">ファイルパス</param>
        public T? Load(string path)
        {
			try
			{
				// 読み込み
				Root = XDocument.Load(path)?.Root;
			}
			catch
			{
				Root = null;
			}

			// オブジェクトを返す
			return GetObject();
		}

        /// <summary>
        /// XMLファイルに保存
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>成功すればtrue</returns>
        public bool Save(T obj, string path)
        {
			// オブジェクトを設定
			SetObject(obj);

			// ルート要素がnullもしくは子要素がない場合は終了
            if (Root?.Elements().FirstOrDefault() == null) return false;

			try
			{
				// フォルダーを作成
				Directory.GetParent(path)?.Create();

				// 出力
				new XDocument(Root).Save(path);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// オブジェクトの取得
		/// </summary>
		/// <returns>オブジェクト</returns>
		protected abstract T? GetObject();

		/// <summary>
		/// オブジェクトの設定
		/// </summary>
		/// <param name="obj">シリアライズしたいオブジェクト</param>
		protected abstract void SetObject(T obj);
	}
}
