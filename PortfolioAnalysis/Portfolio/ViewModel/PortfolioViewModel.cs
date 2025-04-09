using Portfolio.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Portfolio.ViewModel
{
    public class PortfolioViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PortfolioModel> PortfolioHistory { get; set; }
        public ObservableCollection<Brush> Palette { get; set; }
        public ObservableCollection<string> Years { get; set; }
        public string SelectedYear { get; set; }

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

        public PortfolioViewModel()
        {
            PortfolioHistory = new ObservableCollection<PortfolioModel>();
            Palette = new ObservableCollection<Brush>
        {
            new SolidColorBrush(Color.FromArgb("#56EBF5")),
            new SolidColorBrush(Color.FromArgb("#FC922C")),
            new SolidColorBrush(Color.FromArgb("#FC95B2")),
            new SolidColorBrush(Color.FromArgb("#FEE7A0")),
            new SolidColorBrush(Color.FromArgb("#DDB1E1")),
            new SolidColorBrush(Color.FromArgb("#EBD9EB"))
        };
            Years = new ObservableCollection<string> { "2005", "2010", "2015", "2020", "2025" };
            SelectedYear = "2005";

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
                "2005" => new ObservableCollection<PortfolioModel>
            {
                new PortfolioModel("Stocks", 60),
                new PortfolioModel("Bonds", 20),
                new PortfolioModel("Real Estate", 10),
                new PortfolioModel("Gold", 5),
                new PortfolioModel("Cash", 5)
            },
                "2010" => new ObservableCollection<PortfolioModel>
            {
                new PortfolioModel("Stocks", 55),
                new PortfolioModel("Bonds", 25),
                new PortfolioModel("Real Estate", 12),
                new PortfolioModel("Gold", 5),
                new PortfolioModel("Cash", 3)
            },
                "2015" => new ObservableCollection<PortfolioModel>
            {
                new PortfolioModel("Stocks", 50),
                new PortfolioModel("Bonds", 30),
                new PortfolioModel("Real Estate", 15),
                new PortfolioModel("Gold", 4),
                new PortfolioModel("Cash", 1)
            },
                "2020" => new ObservableCollection<PortfolioModel>
            {
                new PortfolioModel("Stocks", 45),
                new PortfolioModel("Bonds", 35),
                new PortfolioModel("Real Estate", 17),
                new PortfolioModel("Gold", 2),
                new PortfolioModel("Cash", 1)
            },
                "2025" => new ObservableCollection<PortfolioModel>
            {
                new PortfolioModel("Stocks", 40),
                new PortfolioModel("Bonds", 40),
                new PortfolioModel("Real Estate", 18),
                new PortfolioModel("Gold", 1),
                new PortfolioModel("Cash", 1)
            },
                _ => PortfolioData
            };
        }

        private void GeneratePortfolioData()
        {
            double initialInvestment = 10000;
            double currentValue = initialInvestment;
            Random rand = new();

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
