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
				string title = Application.ProductName
					+ " Ver." + Application.ProductVersion;
				if (file != null) title = file.Name + " - " + title;
				return title;
			}
		}

		/// <summary>
		/// 未保存の変更があるかどうか
		/// </summary>
		public bool Unsaved { get; private set; }

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

		FileInfo? file = null;

		/// <summary>
		/// 未保存状態の切り替え
		/// </summary>
		public void ToggleUnsavedState() => Unsaved = true;

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
			UpdatedNotice(nameof(Items));
			UpdatedNotice(nameof(Histories));
			UpdatedNotice(nameof(Tags));
		}
	}
}
