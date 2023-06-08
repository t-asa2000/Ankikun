using Ankikun.ViewModels;

namespace Ankikun.Views
{
	public partial class MainView : Form
	{
		MainViewModel viewModel = new();

		public MainView()
		{
			InitializeComponent();

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

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}
	}
}
