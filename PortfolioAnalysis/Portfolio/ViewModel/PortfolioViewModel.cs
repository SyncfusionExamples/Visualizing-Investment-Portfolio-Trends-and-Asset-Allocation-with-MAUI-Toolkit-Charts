using Portfolio.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Portfolio.ViewModel
{
    public record PortfolioViewModel(ObservableCollection<PortfolioModel> PortfolioHistory, ObservableCollection<Brush> Palette, ObservableCollection<string> Years, string SelectedYear) : INotifyPropertyChanged
    {
        private ObservableCollection<PortfolioModel>? _portfolioData;
        public ObservableCollection<PortfolioModel> PortfolioData
        {
            get => _portfolioData!;
            set
            {
                if (_portfolioData != value)
                {
                    _portfolioData = value;
                    OnPropertyChanged(nameof(PortfolioData));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public PortfolioViewModel() : this([], [
                new SolidColorBrush(Color.FromArgb("#56EBF5")),
                new SolidColorBrush(Color.FromArgb("#FC922C")),
                new SolidColorBrush(Color.FromArgb("#FC95B2")),
                new SolidColorBrush(Color.FromArgb("#FEE7A0")),
                new SolidColorBrush(Color.FromArgb("#DDB1E1")),
                new SolidColorBrush(Color.FromArgb("#EBD9EB")),
            ], ["2005", "2010", "2015", "2020", "2025"], "2005")
        {
            UpdatePortfolioData(SelectedYear);
            GeneratePortfolioData();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void UpdatePortfolioData(string year)
        {
            PortfolioData = year switch
            {
                "2005" =>
                [
                    new("Stocks", 60),
                    new("Bonds", 20),
                    new("Real Estate", 10),
                    new("Gold", 5),
                    new("Cash", 5)
                ],
                "2010" =>
                [
                    new("Stocks", 55),
                    new("Bonds", 25),
                    new("Real Estate", 12),
                    new("Gold", 5),
                    new("Cash", 3)
                ],
                "2015" =>
                [
                    new("Stocks", 50),
                    new("Bonds", 30),
                    new("Real Estate", 15),
                    new("Gold", 4),
                    new("Cash", 1)
                ],
                "2020" =>
                [
                    new("Stocks", 45),
                    new("Bonds", 35),
                    new("Real Estate", 17),
                    new("Gold", 2),
                    new("Cash", 1)
                ],
                "2025" =>
                [
                    new("Stocks", 40),
                    new("Bonds", 40),
                    new("Real Estate", 18),
                    new("Gold", 1),
                    new("Cash", 1)
                ],
                _ => PortfolioData
            };
        }
        private void GeneratePortfolioData()
        {
            double initialInvestment = 10000;
            double currentValue = initialInvestment;
            Random random = new();
            Random rand = random;

            for (int year = 2005; year <= 2025; year++)
            {
                double annualReturn = 5 + rand.NextDouble() * 5;
                currentValue *= 1 + annualReturn / 100;

                PortfolioHistory.Add(new PortfolioModel
                {
                    Year = year,
                    PortfolioValue = Math.Round(currentValue, 2),
                    AnnualReturn = Math.Round(annualReturn, 2)
                });
            }
        }
    }
}
