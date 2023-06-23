using System.Xml.Linq;

namespace Ankikun.Models
{
    /// <summary>
    /// XML形式に変換できる型のインターフェース
    /// </summary>
    public interface IXMLObject
    {
        /// <summary>
        /// データが空かどうか
        /// </summary>
        /// <returns>空であればtrue</returns>
        public bool IsEmpty { get; }

        /// <summary>
        /// シリアライズ(XElementを生成)
        /// </summary>
        /// <returns>XElement オブジェクト</returns>
        public XElement? Serialize();

        /// <summary>
        /// シリアライズ(XElementを生成)
        /// </summary>
        /// <returns>XElement オブジェクト</returns>
        public XElement? Serialize(string name);

        /// <summary>
        /// 複数のオブジェクトをまとめてシリアライズ
        /// </summary>
        /// <typeparam name="T">シリアライズしたい型</typeparam>
        /// <param name="objects">オブジェクトの配列</param>
        /// <returns>XElement 配列</returns>
        public static XElement[] Serialize<T>(IEnumerable<T> objects)
        where T : IXMLObject
            => objects.Select(x => x.Serialize())
                .Where(x => x != null)
                .Cast<XElement>()
                .ToArray();

        /// <summary>
        /// 複数のオブジェクトをまとめてシリアライズ
        /// </summary>
        /// <typeparam name="T">シリアライズしたい型</typeparam>
        /// <param name="objects">オブジェクトの配列</param>
        /// <returns>XElement 配列</returns>
        public static XElement[] Serialize<T>(IEnumerable<T> objects, string name)
        where T : IXMLObject
            => objects.Select(x => x.Serialize(name))
                .Where(x => x != null)
                .Cast<XElement>()
                .ToArray();

        /// <summary>
        /// XML要素の値を取得
        /// </summary>
        /// <param name="root">親要素</param>
        /// <param name="name">要素の名前</param>
        /// <returns>XML要素の値</returns>
        public static string GetValue(XElement root, string name)
            => root.Element(name)?.Value ?? "";

        /// <summary>
        /// 指定した要素の全ての子要素の値を取得
        /// </summary>
        /// <param name="root">親要素</param>
        /// <param name="name">要素の名前</param>
        /// <returns>XML要素の値</returns>
        public static string[] GetChildren(XElement root, string name)
            => root.Element(name)?.Elements()
                .Select(x => x.Value)
                .ToArray() ?? Array.Empty<string>();

        /// <summary>
        /// 指定した要素の全ての子要素の値を取得
        /// </summary>
        /// <param name="root">親要素</param>
        /// <param name="name">要素の名前</param>
        /// <param name="childName">子要素の名前</param>
        /// <returns>XML要素の値</returns>
        public static string[] GetChildren(XElement root, string name, string childName)
            => root.Element(name)?.Elements(childName)
                .Select(x => x.Value)
                .ToArray() ?? Array.Empty<string>();
    }
}
