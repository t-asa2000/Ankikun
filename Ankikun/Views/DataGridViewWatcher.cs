namespace Ankikun.Views
{
	/// <summary>
	/// DataGridViewのセルを監視するクラス
	/// </summary>
	internal class DataGridViewWatcher
	{
		/// <summary>
		/// セル監視の有効/無効
		/// </summary>
		public bool Enabled { get; set; } = true;

		/// <summary>
		/// 監視するDataGridView
		/// </summary>
		readonly DataGridView dataGridView;

		/// <summary>
		/// 直前までのセルの値
		/// </summary>
		string?[] values = Array.Empty<string?>();

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		/// <param name="dataGridView">監視するDataGridView</param>
		internal DataGridViewWatcher(DataGridView dataGridView)
		{
			this.dataGridView = dataGridView;
			dataGridView.DataSourceChanged += dataGridView_DataSourceChanged;
		}

		/// <summary>
		/// 変更があったかどうか確認する
		/// </summary>
		/// <returns>変更があればtrue</returns>
		public bool IsChanged()
		{
			if (!Enabled) return false;

			string?[] values = GetCurrentValues();

			// 直前までの値と比較
			bool result = this.values.Length != values.Length;
			for (int i = 0; !result && i < values.Length; i++)
				result = this.values[i] != values[i];

			this.values = values;
			return result;
		}

		/// <summary>
		/// 現在のセルの値を全て取得
		/// </summary>
		/// <returns>現在のセルの値</returns>
		string?[] GetCurrentValues()
		{
			List<string?> values = new();

			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				foreach (DataGridViewColumn col in dataGridView.Columns)
					values.Add(dataGridView[col.Index, row.Index].Value?.ToString());
			}

			return values.ToArray();
		}

		/// <summary>
		/// データソースが変更された時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void dataGridView_DataSourceChanged(object? sender, EventArgs e)
			=> values = GetCurrentValues();
	}
}
