namespace Ankikun.Models
{
	/// <summary>
	/// 確認テストの問題
	/// </summary>
	public struct ExamItem
	{
		/// <summary>
		/// 問題文
		/// </summary>
		public string Question { get; private init; }

		/// <summary>
		/// 答え
		/// </summary>
		public string Answer { get; private init; }

		/// <summary>
		/// 回答済みかどうか
		/// </summary>
		public bool Challenged { get; private set; } = false;

		/// <summary>
		/// 正解したかどうか
		/// </summary>
		public bool Result
		{
			get => result;
			set
			{
				Challenged = true;
				result = value;
			}
		}

		/// <summary>
		/// WorkbookItem オブジェクト
		/// </summary>
		readonly WorkbookItem? baseitem = null;

		/// <summary>
		/// 正解したかどうか
		/// </summary>
		bool result = false;

		/// <summary>
		/// 初期化(コンストラクタ)
		/// </summary>
		/// <param name="baseitem">WorkbookItem オブジェクト</param>
		/// <param name="reverse">問題と答えの反転</param>
		public ExamItem(WorkbookItem baseitem, bool reverse)
		{
			this.baseitem = baseitem;
			Question = reverse ? baseitem.Answer : baseitem.Question;
			Answer = reverse ? baseitem.Question : baseitem.Answer;
		}

		/// <summary>
		/// カウンターを更新
		/// </summary>
		public void UpdateCounter()
		{
			if (Challenged) baseitem?.UpdateCounter(Result);
		}

	}
}
