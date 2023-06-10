using Ankikun.ViewModels;
using System.ComponentModel;
using System.Diagnostics;

namespace Ankikun.Views
{
	/// <summary>
	/// メイン画面(MainView)
	/// </summary>
	public partial class MainView : Form
	{
		/// <summary>
		/// ビューモデル
		/// </summary>
		readonly MainViewModel viewModel = new();

		/// <summary>
		/// itemsDataGridViewのセルを監視するオブジェクト
		/// </summary>
		readonly DataGridViewWatcher itemsWatcher;

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		public MainView()
		{
			InitializeComponent();

			// イベントハンドラの登録
			viewModel.PropertyChanged += viewModel_PropertyChanged;

			// アプリ情報の表示
			ShowAppInfo();

			// DataGridViewセル監視
			itemsWatcher = new(itemsDataGridView);

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
		/// アプリ情報の表示
		/// </summary>
		void ShowAppInfo()
		{
			appInfoLabel.Text = Application.ProductName
				+ " Ver." + Application.ProductVersion
				+ Environment.NewLine + Environment.NewLine
				+ "開発者: " + Application.CompanyName;
		}

		/// <summary>
		/// tagComboBoxの入力候補を更新
		/// </summary>
		void UpdateTagComboBox()
		{
			// 入力候補の内容を更新
			tagComboBox.Items.Clear();
			if (viewModel.Tags.Length > 0)
			{
				tagComboBox.Items.Add("");
				tagComboBox.Items.AddRange(viewModel.Tags);
			}
			
			// 現在の項目が入力候補にない場合
			if (!viewModel.Tags.Contains(tagComboBox.Text))
				tagComboBox.Text = "";
		}

		/// <summary>
		/// ファイル未保存時に警告を表示
		/// </summary>
		/// <param name="next">次の動作を示すキーワード</param>
		/// <returns>押されたボタン</returns>
		DialogResult UnsavedAlert(string next)
		{
			itemsDataGridView.EndEdit();

			// 未保存の変更内容がない場合
			if (!viewModel.Unsaved) return DialogResult.None;

			// メッセージ表示
			string msg = "未保存の内容があります。ファイルを保存しますか?" +
				Environment.NewLine +
				"「いいえ」を選択した場合は、保存しないまま" + next + "ます。";
			DialogResult result = MessageBox.Show(msg,
				Application.ProductName,
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button1);

			// 保存に失敗した場合
			if (result == DialogResult.Yes && !SaveFile())
				return DialogResult.Cancel;

			return result;
		}

		/// <summary>
		/// 新しいファイルを作成
		/// </summary>
		void CreateNewFile()
		{
			// 未保存の変更内容がないか確認
			if (UnsavedAlert("新規作成し") == DialogResult.Cancel) return;

			itemsWatcher.Enabled = false;
			viewModel.CreateNewFile();
			itemsWatcher.Enabled = true;
		}

		/// <summary>
		/// ファイルを開く
		/// </summary>
		void OpenFile()
		{
			// 未保存の変更内容がないか確認
			if (UnsavedAlert("別のファイルを開き") == DialogResult.Cancel) return;

			// セル監視を一時的に無効化
			itemsWatcher.Enabled = false;

			// 成功またはキャンセルの場合
			if (viewModel.OpenFile(out bool cancel) || cancel)
			{
				itemsWatcher.Enabled = true;
				return;
			}

			// 失敗した場合
			itemsWatcher.Enabled = true;
			MessageBox.Show("ファイルが開けませんでした。",
				Application.ProductName,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1);
		}

		/// <summary>
		/// ファイルを保存
		/// </summary>
		/// <returns>成功したらtrue</returns>
		bool SaveFile()
		{
			// 成功またはキャンセルの場合
			if (viewModel.SaveFile(out bool cancel) || cancel) return !cancel;

			// 失敗した場合
			MessageBox.Show("正常に保存できませんでした。",
				Application.ProductName,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1);
			return false;
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
			// 行の高さの調整
			itemsDataGridView.AutoResizeRow(e.RowIndex, DataGridViewAutoSizeRowMode.AllCells);
			int height = itemsDataGridView.Rows[e.RowIndex].Height;
			itemsDataGridView.Rows[e.RowIndex].Height = (int)(height * 1.5);

			if (itemsWatcher.IsChanged()) viewModel.EnableUnsavedState();
			UpdateTagComboBox();
		}

		/// <summary>
		/// itemDataGridViewの行が削除された時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void itemsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (itemsWatcher.IsChanged()) viewModel.EnableUnsavedState();
			UpdateTagComboBox();
		}

		/// <summary>
		/// 新規作成ボタンクリック時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void createToolStripButton_Click(object sender, EventArgs e) => CreateNewFile();

		/// <summary>
		/// 開くボタンクリック時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void openToolStripButton_Click(object sender, EventArgs e) => OpenFile();

		/// <summary>
		/// 保存ボタンクリック時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void saveToolStripButton_Click(object sender, EventArgs e) => SaveFile();

		/// <summary>
		/// 「公式 GitHub ページを開く」ボタンクリック時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void githubButton_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo()
			{
				UseShellExecute = true,
				FileName = "https://github.com/t-asa2000/Ankikun"
			});
		}

		/// <summary>
		/// 「最新版のダウンロード」ボタンクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void releasesButton_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo()
			{
				UseShellExecute = true,
				FileName = "https://github.com/t-asa2000/Ankikun/releases"
			});
		}

		/// <summary>
		/// フォームを閉じる時
		/// </summary>
		/// <param name="sender">送信元のオブジェクト</param>
		/// <param name="e">イベント引数</param>
		void MainView_FormClosing(object sender, FormClosingEventArgs e)
		{
			// 未保存の変更内容がないか確認
			e.Cancel = UnsavedAlert("終了し") == DialogResult.Cancel;
		}
	}
}
