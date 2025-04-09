using Syncfusion.Maui.Toolkit.Charts;
namespace Portfolio
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            dateTimeChart.XAxes[0].LabelCreated += Primary_LabelCreated;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is Picker picker && picker.SelectedItem is string selectedYear)
            {
                viewModel.UpdatePortfolioData(selectedYear);
            }
        }

        int _month = int.MaxValue;

        private void Primary_LabelCreated(object? sender, ChartAxisLabelEventArgs e)
        {
            DateTime baseDate = new(2005, 01, 25);
            var date = baseDate.AddDays(e.Position);
            if (date.Month != _month)
            {
                ChartAxisLabelStyle labelStyle = new()
                {
                    LabelFormat = "MMM-dd",
                    FontAttributes = FontAttributes.Bold
                };
                e.LabelStyle = labelStyle;

                _month = date.Month;
            }
            else
            {
                ChartAxisLabelStyle labelStyle = new()
                {
                    LabelFormat = "dd"
                };
                e.LabelStyle = labelStyle;
            }
        }
    }

}
