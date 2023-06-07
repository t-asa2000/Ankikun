using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ankikun.Models
{
	/// <summary>
	/// 問題集(ワークブック)
	/// </summary>
	[XmlRoot]
	public class Workbook
	{
		/// <summary>
		/// 問題
		/// </summary>
		[XmlArray]
		public BindingList<WorkbookItem> Items { get; set; } = new();

		/// <summary>
		/// 確認テストの履歴
		/// </summary>
		[XmlArray]
		public BindingList<ExamHistory> Histories { get; set; } = new();

		/// <summary>
		/// XMLシリアライザー
		/// </summary>
		readonly static XmlSerializer serializer = new(typeof(Workbook));

		/// <summary>
		/// XML出力設定
		/// </summary>
		readonly static XmlWriterSettings writerSettings = new()
		{
			// エンコードをUTF-8にする
			Encoding = new UTF8Encoding(false),
			// インデントを有効にする
			Indent = true,
			// インデントをタブにする
			IndentChars = "\t"
		};

		/// <summary>
		/// 確認テストの開始
		/// </summary>
		/// <param name="config">条件設定</param>
		/// <returns>確認問題</returns>
		public ExamItem[] StartExam(ExamConfig config)
		{
			IEnumerable<ExamItem> items = Items
				.Where(x => !config.LowRate || x.Rate < 50)
				.Where(y => string.IsNullOrWhiteSpace(config.Tag)
					|| y.Tags.Contains(config.Tag))
				.Select(z => new ExamItem(z, config.Reverse));

			if (config.Shuffle) items = items.OrderBy(x => Guid.NewGuid());

			return items.ToArray();
		}

		/// <summary>
		/// 確認テストの終了
		/// </summary>
		/// <param name="items">確認問題</param>
		/// <param name="config">条件設定</param>
		/// <returns>確認テストの履歴</returns>
		public ExamHistory FinishExam(ExamItem[] items, ExamConfig config)
		{
			foreach (ExamItem item in items) item.UpdateCounter();

			ExamHistory history = new();
			history.Cleared = items.Where(x => x.Result).Count();
			history.Answered = items.Where(x => x.Challenged).Count();
			history.Config = config;
			
			Histories.Insert(0, history);

			return history;
		}

		/// <summary>
		/// XMLファイルから読み込み
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>読み込めたらオブジェクトを返す</returns>
		public static Workbook? LoadXML(string path)
		{
			XmlReader? reader = null;
			Workbook? imported = null;

			try
			{
				/// 読み込み
				reader = XmlReader.Create(path);
				imported = (Workbook?)serializer.Deserialize(reader);
			}
			catch (Exception)
			{

			}

			// ファイルを閉じる
			reader?.Close();
			return imported;
		}

		/// <summary>
		/// XMLファイルとして保存
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>保存できたかどうか</returns>
		public bool SaveXML(string path)
		{
			XmlWriter? writer = null;
			bool result = true;

			try
			{
				// フォルダが存在しなければ作成
				DirectoryInfo? dir = Directory.GetParent(path);
				if (dir == null) return false;
				dir.Create();

				// 保存
				writer = XmlWriter.Create(path, writerSettings);
				serializer.Serialize(writer, this);
			}
			catch (Exception)
			{
				result = false;
			}

			// ファイルを閉じる
			writer?.Close();
			return result;
		}
	}
}
