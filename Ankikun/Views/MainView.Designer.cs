namespace Ankikun.Views
{
	partial class MainView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.examConfigTab = new System.Windows.Forms.TabPage();
			this.startButton = new System.Windows.Forms.Button();
			this.tagComboBoxLabel = new System.Windows.Forms.Label();
			this.tagComboBox = new System.Windows.Forms.ComboBox();
			this.lowRateCheckBox = new System.Windows.Forms.CheckBox();
			this.reverseCheckBox = new System.Windows.Forms.CheckBox();
			this.shuffleCheckBox = new System.Windows.Forms.CheckBox();
			this.strictCheckBox = new System.Windows.Forms.CheckBox();
			this.historiesTab = new System.Windows.Forms.TabPage();
			this.historiesDataGridView = new System.Windows.Forms.DataGridView();
			this.itemsTab = new System.Windows.Forms.TabPage();
			this.itemsDataGridView = new System.Windows.Forms.DataGridView();
			this.mainToolbar = new System.Windows.Forms.ToolStrip();
			this.新規NToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.開くOToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.mainTableLayoutPanel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.examConfigTab.SuspendLayout();
			this.historiesTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.historiesDataGridView)).BeginInit();
			this.itemsTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).BeginInit();
			this.mainToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.ColumnCount = 1;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mainTableLayoutPanel.Controls.Add(this.mainToolbar, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.tabControl, 0, 1);
			this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 2;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(977, 656);
			this.mainTableLayoutPanel.TabIndex = 0;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.examConfigTab);
			this.tabControl.Controls.Add(this.historiesTab);
			this.tabControl.Controls.Add(this.itemsTab);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(3, 43);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(971, 610);
			this.tabControl.TabIndex = 1;
			// 
			// examConfigTab
			// 
			this.examConfigTab.Controls.Add(this.startButton);
			this.examConfigTab.Controls.Add(this.tagComboBoxLabel);
			this.examConfigTab.Controls.Add(this.tagComboBox);
			this.examConfigTab.Controls.Add(this.lowRateCheckBox);
			this.examConfigTab.Controls.Add(this.reverseCheckBox);
			this.examConfigTab.Controls.Add(this.shuffleCheckBox);
			this.examConfigTab.Controls.Add(this.strictCheckBox);
			this.examConfigTab.Location = new System.Drawing.Point(4, 29);
			this.examConfigTab.Name = "examConfigTab";
			this.examConfigTab.Padding = new System.Windows.Forms.Padding(3);
			this.examConfigTab.Size = new System.Drawing.Size(963, 577);
			this.examConfigTab.TabIndex = 0;
			this.examConfigTab.Text = "確認テスト";
			this.examConfigTab.UseVisualStyleBackColor = true;
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(319, 295);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(112, 37);
			this.startButton.TabIndex = 10;
			this.startButton.Text = "開始";
			this.startButton.UseVisualStyleBackColor = true;
			// 
			// tagComboBoxLabel
			// 
			this.tagComboBoxLabel.AutoSize = true;
			this.tagComboBoxLabel.Location = new System.Drawing.Point(18, 146);
			this.tagComboBoxLabel.Name = "tagComboBoxLabel";
			this.tagComboBoxLabel.Size = new System.Drawing.Size(76, 20);
			this.tagComboBoxLabel.TabIndex = 9;
			this.tagComboBoxLabel.Text = "タグを指定:";
			// 
			// tagComboBox
			// 
			this.tagComboBox.FormattingEnabled = true;
			this.tagComboBox.Location = new System.Drawing.Point(18, 175);
			this.tagComboBox.Name = "tagComboBox";
			this.tagComboBox.Size = new System.Drawing.Size(413, 28);
			this.tagComboBox.TabIndex = 8;
			// 
			// lowRateCheckBox
			// 
			this.lowRateCheckBox.AutoSize = true;
			this.lowRateCheckBox.Location = new System.Drawing.Point(18, 109);
			this.lowRateCheckBox.Name = "lowRateCheckBox";
			this.lowRateCheckBox.Size = new System.Drawing.Size(170, 24);
			this.lowRateCheckBox.TabIndex = 4;
			this.lowRateCheckBox.Text = "正答率の低い問題のみ";
			this.lowRateCheckBox.UseVisualStyleBackColor = true;
			// 
			// reverseCheckBox
			// 
			this.reverseCheckBox.AutoSize = true;
			this.reverseCheckBox.Location = new System.Drawing.Point(18, 79);
			this.reverseCheckBox.Name = "reverseCheckBox";
			this.reverseCheckBox.Size = new System.Drawing.Size(176, 24);
			this.reverseCheckBox.TabIndex = 5;
			this.reverseCheckBox.Text = "問題と答えを入れ替える";
			this.reverseCheckBox.UseVisualStyleBackColor = true;
			// 
			// shuffleCheckBox
			// 
			this.shuffleCheckBox.AutoSize = true;
			this.shuffleCheckBox.Location = new System.Drawing.Point(18, 49);
			this.shuffleCheckBox.Name = "shuffleCheckBox";
			this.shuffleCheckBox.Size = new System.Drawing.Size(136, 24);
			this.shuffleCheckBox.TabIndex = 6;
			this.shuffleCheckBox.Text = "シャッフルして出題";
			this.shuffleCheckBox.UseVisualStyleBackColor = true;
			// 
			// strictCheckBox
			// 
			this.strictCheckBox.AutoSize = true;
			this.strictCheckBox.Location = new System.Drawing.Point(18, 19);
			this.strictCheckBox.Name = "strictCheckBox";
			this.strictCheckBox.Size = new System.Drawing.Size(123, 24);
			this.strictCheckBox.TabIndex = 7;
			this.strictCheckBox.Text = "厳格採点モード";
			this.strictCheckBox.UseVisualStyleBackColor = true;
			// 
			// historiesTab
			// 
			this.historiesTab.Controls.Add(this.historiesDataGridView);
			this.historiesTab.Location = new System.Drawing.Point(4, 29);
			this.historiesTab.Name = "historiesTab";
			this.historiesTab.Padding = new System.Windows.Forms.Padding(3);
			this.historiesTab.Size = new System.Drawing.Size(963, 577);
			this.historiesTab.TabIndex = 1;
			this.historiesTab.Text = "履歴";
			this.historiesTab.UseVisualStyleBackColor = true;
			// 
			// historiesDataGridView
			// 
			this.historiesDataGridView.AllowUserToAddRows = false;
			this.historiesDataGridView.AllowUserToOrderColumns = true;
			this.historiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.historiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.historiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.historiesDataGridView.Location = new System.Drawing.Point(3, 3);
			this.historiesDataGridView.Name = "historiesDataGridView";
			this.historiesDataGridView.ReadOnly = true;
			this.historiesDataGridView.RowHeadersWidth = 51;
			this.historiesDataGridView.RowTemplate.Height = 29;
			this.historiesDataGridView.Size = new System.Drawing.Size(957, 571);
			this.historiesDataGridView.TabIndex = 1;
			// 
			// itemsTab
			// 
			this.itemsTab.Controls.Add(this.itemsDataGridView);
			this.itemsTab.Location = new System.Drawing.Point(4, 29);
			this.itemsTab.Name = "itemsTab";
			this.itemsTab.Padding = new System.Windows.Forms.Padding(3);
			this.itemsTab.Size = new System.Drawing.Size(963, 577);
			this.itemsTab.TabIndex = 2;
			this.itemsTab.Text = "問題集";
			this.itemsTab.UseVisualStyleBackColor = true;
			// 
			// itemsDataGridView
			// 
			this.itemsDataGridView.AllowUserToOrderColumns = true;
			this.itemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.itemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsDataGridView.Location = new System.Drawing.Point(3, 3);
			this.itemsDataGridView.Name = "itemsDataGridView";
			this.itemsDataGridView.RowHeadersWidth = 51;
			this.itemsDataGridView.RowTemplate.Height = 29;
			this.itemsDataGridView.Size = new System.Drawing.Size(957, 571);
			this.itemsDataGridView.TabIndex = 1;
			// 
			// mainToolbar
			// 
			this.mainToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mainToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規NToolStripButton,
            this.開くOToolStripButton,
            this.保存SToolStripButton});
			this.mainToolbar.Location = new System.Drawing.Point(0, 0);
			this.mainToolbar.Name = "mainToolbar";
			this.mainToolbar.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
			this.mainToolbar.Size = new System.Drawing.Size(977, 40);
			this.mainToolbar.TabIndex = 4;
			this.mainToolbar.Text = "toolStrip1";
			// 
			// 新規NToolStripButton
			// 
			this.新規NToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("新規NToolStripButton.Image")));
			this.新規NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.新規NToolStripButton.Name = "新規NToolStripButton";
			this.新規NToolStripButton.Size = new System.Drawing.Size(114, 31);
			this.新規NToolStripButton.Text = "新規作成(&N)";
			// 
			// 開くOToolStripButton
			// 
			this.開くOToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("開くOToolStripButton.Image")));
			this.開くOToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.開くOToolStripButton.Name = "開くOToolStripButton";
			this.開くOToolStripButton.Size = new System.Drawing.Size(78, 31);
			this.開くOToolStripButton.Text = "開く(&O)";
			// 
			// 保存SToolStripButton
			// 
			this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
			this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.保存SToolStripButton.Name = "保存SToolStripButton";
			this.保存SToolStripButton.Size = new System.Drawing.Size(81, 31);
			this.保存SToolStripButton.Text = "保存(&S)";
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(977, 656);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Name = "MainView";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.examConfigTab.ResumeLayout(false);
			this.examConfigTab.PerformLayout();
			this.historiesTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.historiesDataGridView)).EndInit();
			this.itemsTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).EndInit();
			this.mainToolbar.ResumeLayout(false);
			this.mainToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel mainTableLayoutPanel;
		private TabControl tabControl;
		private TabPage examConfigTab;
		private TabPage historiesTab;
		private TabPage itemsTab;
		private DataGridView historiesDataGridView;
		private DataGridView itemsDataGridView;
		private Button startButton;
		private Label tagComboBoxLabel;
		private ComboBox tagComboBox;
		private CheckBox lowRateCheckBox;
		private CheckBox reverseCheckBox;
		private CheckBox shuffleCheckBox;
		private CheckBox strictCheckBox;
		private ToolStrip mainToolbar;
		private ToolStripButton 新規NToolStripButton;
		private ToolStripButton 開くOToolStripButton;
		private ToolStripButton 保存SToolStripButton;
	}
}