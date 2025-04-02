namespace portfolio
{
    public class PortfolioModel
    {
        public int Year { get; set; }
        public double PortfolioValue { get; set; }
        public double AnnualReturn { get; set; }
        public string? Sector { get; set; }
        public double Value { get; set; }
        public PortfolioModel(string? sector, double value)
        {
            Sector = sector;
            Value = value;
        }

        public PortfolioModel()
        {
        }
    }
}
