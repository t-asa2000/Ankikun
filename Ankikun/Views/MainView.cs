using Ankikun.ViewModels;
using System.ComponentModel;

namespace Ankikun.Views
{
	public partial class MainView : Form
	{
		readonly MainViewModel viewModel = new();

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		public MainView()
		{
			InitializeComponent();

			// イベントハンドラの登録
			viewModel.PropertyChanged += viewModel_PropertyChanged;

			// データバインド
			DataBindings.Add(nameof(Text), viewModel, nameof(viewModel.WindowTitle));

			strictCheckBox.DataBindings.Add(nameof(CheckBox.Checked)
				, viewModel, nameof(viewModel.Exam_Strict));
			shuffleCheckBox.DataBindings.Add(nameof(CheckBox.Checked)
				, viewModel, nameof(viewModel.Exam_Shuffle));
			reverseCheckBox.DataBindings.Add(nameof(CheckBox.Checked)
				, viewModel, nameof(viewModel.Exam_Reverse));
			lowRateCheckBox.DataBindings.Add(nameof(CheckBox.Checked)
				, viewModel, nameof(viewModel.Exam_LowRate));

			itemsDataGridView.DataBindings.Add(nameof(DataGridView.DataSource)
				, viewModel, nameof(viewModel.Items));
			historiesDataGridView.DataBindings.Add(nameof(DataGridView.DataSource)
				, viewModel, nameof(viewModel.Histories));
		}

		/// <summary>
		/// tagComboBoxの入力候補を更新
		/// </summary>
		void UpdateTagComboBox()
		{
			tagComboBox.Items.Clear();
			if (viewModel.Tags.Length > 0)
			{
				tagComboBox.Items.Add("");
				tagComboBox.Items.AddRange(viewModel.Tags);
			}
				
			if (!viewModel.Tags.Contains(tagComboBox.Text))
				tagComboBox.Text = "";
		}

		/// <summary>
		/// ビューモデルのプロパティが変更された時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void viewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(viewModel.Tags)) UpdateTagComboBox();
		}

		/// <summary>
		/// itemDataGridViewのセルの編集が終わった時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void itemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			UpdateTagComboBox();
		}

		/// <summary>
		/// itemDataGridViewの行が削除された時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void itemsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			UpdateTagComboBox();
		}
	}
}
