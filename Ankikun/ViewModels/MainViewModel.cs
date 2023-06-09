using Ankikun.Models;
using System.ComponentModel;

namespace Ankikun.ViewModels
{
	/// <summary>
	/// MainView用のビューモデル
	/// </summary>
	internal class MainViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// 確認テスト: 厳格採点モード
		/// </summary>
		public bool Exam_Strict
		{
			get => exam.Strict;
			set
			{
				exam.Strict = value;
				UpdatedNotice(nameof(Exam_Strict));
			}
		}

		/// <summary>
		/// 確認テスト: 問題と答えの反転
		/// </summary>
		public bool Exam_Reverse
		{
			get => exam.Reverse;
			set
			{
				exam.Reverse = value;
				UpdatedNotice(nameof(Exam_Reverse));
			}
		}

		/// <summary>
		/// 確認テスト: シャッフルして出題
		/// </summary>
		public bool Exam_Shuffle
		{
			get => exam.Shuffle;
			set
			{
				exam.Shuffle = value;
				UpdatedNotice(nameof(Exam_Shuffle));
			}
		}

		/// <summary>
		/// 確認テスト: 正答率の低い問題のみ
		/// </summary>
		public bool Exam_LowRate
		{
			get => exam.LowRate;
			set
			{
				exam.LowRate = value;
				UpdatedNotice(nameof(Exam_LowRate));
			}
		}

		/// <summary>
		/// 確認テスト: タグ指定
		/// </summary>
		public string Exam_Tag
		{
			get => exam.Tag;
			set
			{
				exam.Tag = value;
				UpdatedNotice(nameof(Exam_Tag));
			}
		}

		/// <summary>
		/// ウインドウタイトル
		/// </summary>
		public string WindowTitle
		{
			get
			{
				string title = unsaved ? "*" : "";
				title += file?.Name ?? "無題.xml";
				title += " - " + Application.ProductName
					+ " Ver." + Application.ProductVersion;
				return title;
			}
		}

		/// <summary>
		/// 未保存の変更があるかどうか
		/// </summary>
		public bool Unsaved
		{
			get => unsaved;
			private set
			{
				unsaved = value;
				UpdatedNotice(nameof(WindowTitle));
			}
		}

		/// <summary>
		/// ワークブックの問題
		/// </summary>
		public BindingList<WorkbookItem> Items => workbook.Items;

		/// <summary>
		/// 確認テストの履歴
		/// </summary>
		public BindingList<ExamHistory> Histories => workbook.Histories;

		/// <summary>
		/// 全ての問題のタグ
		/// </summary>
		public string[] Tags => Items.SelectMany(x => x.Tags).Distinct().ToArray();

		/// <summary>
		/// プロパティが変更されたとき
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// 問題集(ワークブック)
		/// </summary>
		Workbook workbook = new();

		/// <summary>
		/// 確認テストの条件設定
		/// </summary>
		ExamConfig exam;

		/// <summary>
		/// 開いているファイル
		/// </summary>
		FileInfo? file = null;

		/// <summary>
		/// 未保存の変更があるかどうか
		/// </summary>
		bool unsaved;

		/// <summary>
		/// 未保存状態にする(未保存の変更があることを知らせる)
		/// </summary>
		public void EnableUnsavedState() => Unsaved = true;

		/// <summary>
		/// 新しいファイルを作成
		/// </summary>
		public void CreateNewFile() => ChangeWorkbook(new());

		/// <summary>
		/// ファイルを開く
		/// </summary>
		/// <remarks>
		/// 「開く」ダイアログボックスを使用
		/// </remarks>
		/// <returns>成功したらtrue</returns>
		public bool OpenFile() => OpenFile(out _);

		/// <summary>
		/// ファイルを開く
		/// </summary>
		/// <remarks>
		/// 「開く」ダイアログボックスを使用
		/// </remarks>
		/// <param name="cancel">キャンセルされたかどうか</param>
		/// <returns>成功したらtrue</returns>
		public bool OpenFile(out bool cancel)
		{
			OpenFileDialog ofd = new()
			{
				Title = "開く",
				Filter = "XML ファイル(*.xml)|*.xml",
				FileName = file?.Name ?? "",
				RestoreDirectory = true
			};

			if (Directory.Exists(file?.DirectoryName))
				ofd.InitialDirectory = file?.DirectoryName ?? "";

			cancel = ofd.ShowDialog() != DialogResult.OK;
			string path = ofd.FileName;
			ofd.Dispose();

			return !cancel && OpenFile(path);
		}

		/// <summary>
		/// ファイルを開く
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>成功したらtrue</returns>
		public bool OpenFile(string path)
		{
			Workbook? workbook = Workbook.LoadXML(path);
			if (workbook != null)
			{
				if (file?.FullName != path) file = new(path);
				ChangeWorkbook(workbook);
				return true;
			}
			return false;
		}

		/// <summary>
		/// ファイルを保存
		/// </summary>
		/// <remarks>
		/// 「名前を付けて保存」ダイアログボックスを使用
		/// </remarks>
		/// <returns>成功したらtrue</returns>
		public bool SaveFile() => SaveFile(out _);

		/// <summary>
		/// ファイルを保存
		/// </summary>
		/// <remarks>
		/// 「名前を付けて保存」ダイアログボックスを使用
		/// </remarks>
		/// <param name="cancel">キャンセルされたかどうか</param>
		/// <returns>成功したらtrue</returns>
		public bool SaveFile(out bool cancel)
		{
			SaveFileDialog sfd = new()
			{
				Title = "名前を付けて保存",
				Filter = "XML ファイル(*.xml)|*.xml",
				FileName = file?.Name ?? "",
				RestoreDirectory = true
			};

			if (Directory.Exists(file?.DirectoryName))
				sfd.InitialDirectory = file?.DirectoryName ?? "";

			cancel = sfd.ShowDialog() != DialogResult.OK;
			string path = sfd.FileName;
			sfd.Dispose();

			return !cancel && SaveFile(path);
		}

		/// <summary>
		/// ファイルを保存
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <returns>成功したらtrue</returns>
		public bool SaveFile(string path)
		{
			if (workbook.SaveXML(path))
			{
				if (file?.FullName != path) file = new(path);
				Unsaved = false;
				return true;
			}
			return false;
		}

		/// <summary>
		/// プロパティの変更をビューに知らせる
		/// </summary>
		/// <param name="propertyName">プロパティ名</param>
		void UpdatedNotice(string? propertyName)
			=> PropertyChanged?.Invoke(this, new(propertyName));

		/// <summary>
		/// 問題集(ワークブック)を入れ替える
		/// </summary>
		/// <param name="workbook">新しい Workbook オブジェクト</param>
		void ChangeWorkbook(Workbook workbook)
		{
			this.workbook = workbook;
			Unsaved = false;
			UpdatedNotice(nameof(Items));
			UpdatedNotice(nameof(Histories));
			UpdatedNotice(nameof(Tags));
		}
	}
}
