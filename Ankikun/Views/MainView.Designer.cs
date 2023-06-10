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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.mainToolbar = new System.Windows.Forms.ToolStrip();
			this.createToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
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
			this.appInfoTabPage = new System.Windows.Forms.TabPage();
			this.releasesButton = new System.Windows.Forms.Button();
			this.githubButton = new System.Windows.Forms.Button();
			this.appInfoLabel = new System.Windows.Forms.Label();
			this.mainTableLayoutPanel.SuspendLayout();
			this.mainToolbar.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.examConfigTab.SuspendLayout();
			this.historiesTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.historiesDataGridView)).BeginInit();
			this.itemsTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).BeginInit();
			this.appInfoTabPage.SuspendLayout();
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
			// mainToolbar
			// 
			this.mainToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mainToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton});
			this.mainToolbar.Location = new System.Drawing.Point(0, 0);
			this.mainToolbar.Name = "mainToolbar";
			this.mainToolbar.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
			this.mainToolbar.Size = new System.Drawing.Size(977, 40);
			this.mainToolbar.TabIndex = 4;
			this.mainToolbar.Text = "toolStrip1";
			// 
			// createToolStripButton
			// 
			this.createToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("createToolStripButton.Image")));
			this.createToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createToolStripButton.Name = "createToolStripButton";
			this.createToolStripButton.Size = new System.Drawing.Size(114, 31);
			this.createToolStripButton.Text = "新規作成(&N)";
			this.createToolStripButton.Click += new System.EventHandler(this.createToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(78, 31);
			this.openToolStripButton.Text = "開く(&O)";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(81, 31);
			this.saveToolStripButton.Text = "保存(&S)";
			this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.examConfigTab);
			this.tabControl.Controls.Add(this.historiesTab);
			this.tabControl.Controls.Add(this.itemsTab);
			this.tabControl.Controls.Add(this.appInfoTabPage);
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
			this.lowRateCheckBox.Size = new System.Drawing.Size(171, 24);
			this.lowRateCheckBox.TabIndex = 4;
			this.lowRateCheckBox.Text = "正答率が低い問題のみ";
			this.lowRateCheckBox.UseVisualStyleBackColor = true;
			// 
			// reverseCheckBox
			// 
			this.reverseCheckBox.AutoSize = true;
			this.reverseCheckBox.Location = new System.Drawing.Point(18, 49);
			this.reverseCheckBox.Name = "reverseCheckBox";
			this.reverseCheckBox.Size = new System.Drawing.Size(176, 24);
			this.reverseCheckBox.TabIndex = 5;
			this.reverseCheckBox.Text = "問題と答えを入れ替える";
			this.reverseCheckBox.UseVisualStyleBackColor = true;
			// 
			// shuffleCheckBox
			// 
			this.shuffleCheckBox.AutoSize = true;
			this.shuffleCheckBox.Location = new System.Drawing.Point(18, 79);
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
			this.historiesDataGridView.AllowUserToResizeRows = false;
			this.historiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.historiesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.historiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.historiesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
			this.historiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.historiesDataGridView.Location = new System.Drawing.Point(3, 3);
			this.historiesDataGridView.Name = "historiesDataGridView";
			this.historiesDataGridView.ReadOnly = true;
			this.historiesDataGridView.RowHeadersWidth = 51;
			this.historiesDataGridView.RowTemplate.Height = 33;
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
			this.itemsDataGridView.AllowUserToResizeRows = false;
			this.itemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.itemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.itemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.itemsDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
			this.itemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsDataGridView.Location = new System.Drawing.Point(3, 3);
			this.itemsDataGridView.Name = "itemsDataGridView";
			this.itemsDataGridView.RowHeadersWidth = 51;
			this.itemsDataGridView.RowTemplate.Height = 33;
			this.itemsDataGridView.Size = new System.Drawing.Size(957, 571);
			this.itemsDataGridView.TabIndex = 1;
			this.itemsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsDataGridView_CellEndEdit);
			this.itemsDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.itemsDataGridView_RowsRemoved);
			// 
			// appInfoTabPage
			// 
			this.appInfoTabPage.Controls.Add(this.releasesButton);
			this.appInfoTabPage.Controls.Add(this.githubButton);
			this.appInfoTabPage.Controls.Add(this.appInfoLabel);
			this.appInfoTabPage.Location = new System.Drawing.Point(4, 29);
			this.appInfoTabPage.Name = "appInfoTabPage";
			this.appInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.appInfoTabPage.Size = new System.Drawing.Size(963, 577);
			this.appInfoTabPage.TabIndex = 3;
			this.appInfoTabPage.Text = "アプリ情報";
			this.appInfoTabPage.UseVisualStyleBackColor = true;
			// 
			// releasesButton
			// 
			this.releasesButton.Location = new System.Drawing.Point(15, 182);
			this.releasesButton.Name = "releasesButton";
			this.releasesButton.Size = new System.Drawing.Size(325, 41);
			this.releasesButton.TabIndex = 1;
			this.releasesButton.Text = "最新版のダウンロード";
			this.releasesButton.UseVisualStyleBackColor = true;
			this.releasesButton.Click += new System.EventHandler(this.releasesButton_Click);
			// 
			// githubButton
			// 
			this.githubButton.Location = new System.Drawing.Point(15, 135);
			this.githubButton.Name = "githubButton";
			this.githubButton.Size = new System.Drawing.Size(325, 41);
			this.githubButton.TabIndex = 1;
			this.githubButton.Text = "公式 GitHub ページを開く";
			this.githubButton.UseVisualStyleBackColor = true;
			this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
			// 
			// appInfoLabel
			// 
			this.appInfoLabel.Location = new System.Drawing.Point(15, 17);
			this.appInfoLabel.Name = "appInfoLabel";
			this.appInfoLabel.Size = new System.Drawing.Size(325, 106);
			this.appInfoLabel.TabIndex = 0;
			this.appInfoLabel.Text = "[製品名] [製品バージョン]\r\n\r\n開発者: [会社名]";
			this.appInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(977, 656);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Name = "MainView";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			this.mainToolbar.ResumeLayout(false);
			this.mainToolbar.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.examConfigTab.ResumeLayout(false);
			this.examConfigTab.PerformLayout();
			this.historiesTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.historiesDataGridView)).EndInit();
			this.itemsTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).EndInit();
			this.appInfoTabPage.ResumeLayout(false);
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
		private ToolStripButton createToolStripButton;
		private ToolStripButton openToolStripButton;
		private ToolStripButton saveToolStripButton;
		private TabPage appInfoTabPage;
		private Button githubButton;
		private Label appInfoLabel;
		private Button releasesButton;
	}
}