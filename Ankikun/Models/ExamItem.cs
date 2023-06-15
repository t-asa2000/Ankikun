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
		public string Question { get; }

		/// <summary>
		/// 答え
		/// </summary>
		public string Answer { get; }

		/// <summary>
		/// 回答済みかどうか
		/// </summary>
		public bool Answered { get; private set; } = false;

		/// <summary>
		/// 正解したかどうか
		/// </summary>
		public bool Result
		{
			get => result;
			set
			{
				Answered = true;
				result = value;
			}
		}

		/// @private
		/// <summary>
		/// WorkbookItem オブジェクト
		/// </summary>
		readonly WorkbookItem baseitem;

		/// @private
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
			if (Answered) baseitem.UpdateCounter(Result);
		}

	}
}
