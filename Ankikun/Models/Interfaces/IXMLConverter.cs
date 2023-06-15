namespace Ankikun.Models.Interfaces
{
	/// <summary>
	/// XMLファイルを読み込み・生成する型のインターフェース
	/// </summary>
	/// <typeparam name="T">シリアライズしたい型</typeparam>
	public interface IXMLConverter<T>
	where T : IXMLObject
	{
		/// <summary>
		/// オブジェクトの登録
		/// </summary>
		/// <param name="obj">シリアライズしたいオブジェクト</param>
		public void SetObject(T obj);

		/// <summary>
		/// オブジェクトを取得
		/// </summary>
		/// <returns>オブジェクト</returns>
		public T? GetObject();

		/// <summary>
		/// XMLファイルから読み込み
		/// </summary>
		/// <param name="path">ファイルパス</param>
		public void Load(string path);

		/// <summary>
		/// XMLファイルに保存
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>成功すればtrue</returns>
		public bool Save(string path);
	}
}
