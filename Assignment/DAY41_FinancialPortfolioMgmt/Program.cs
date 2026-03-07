using System;
using System.Collections.Generic;
using System.Linq;

namespace DAY41_FinancialPortfolioMgmt
{
   
    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }


    abstract class FinancialInstrument
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string currency;
        public string Currency
        {
            get => currency;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be 3-letter code");

                currency = value.ToUpper();
            }
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value <= 0)
                    throw new InvalidFinancialDataException("Quantity must be positive");

                quantity = value;
            }
        }

        private decimal purchasePrice;
        public decimal PurchasePrice
        {
            get => purchasePrice;
            set
            {
                if (value <= 0)
                    throw new InvalidFinancialDataException("Purchase price must be positive");

                purchasePrice = value;
            }
        }

        private decimal marketPrice;
        public decimal MarketPrice
        {
            get => marketPrice;
            set
            {
                if (value <= 0)
                    throw new InvalidFinancialDataException("Market price must be positive");

                marketPrice = value;
            }
        }

        public DateTime PurchaseDate { get; set; }

       
        protected FinancialInstrument(int id, string name, string currency,
            int quantity, decimal purchasePrice, decimal marketPrice, DateTime purchaseDate)
        {
            Id = id;
            Name = name;
            Currency = currency;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            MarketPrice = marketPrice;
            PurchaseDate = purchaseDate;
        }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{Name} ({Currency}) → {CalculateCurrentValue():C}";
        }
    }

    
    class Equity : FinancialInstrument
    {
        public Equity(int id, string name, string currency,
            int quantity, decimal purchasePrice, decimal marketPrice, DateTime purchaseDate)
            : base(id, name, currency, quantity, purchasePrice, marketPrice, purchaseDate) { }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

   
    class MutualFund : FinancialInstrument
    {
        public MutualFund(int id, string name, string currency,
            int quantity, decimal purchasePrice, decimal marketPrice, DateTime purchaseDate)
            : base(id, name, currency, quantity, purchasePrice, marketPrice, purchaseDate) { }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }


    class Bond : FinancialInstrument
    {
        public Bond(int id, string name, string currency,
            int quantity, decimal purchasePrice, decimal marketPrice, DateTime purchaseDate)
            : base(id, name, currency, quantity, purchasePrice, marketPrice, purchaseDate) { }

        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

  
    class FixedDeposit : FinancialInstrument
    {
        public decimal InterestRate { get; set; }
        public int TimePeriod { get; set; }

        public FixedDeposit(int id, string name, string currency,
            int quantity, decimal purchasePrice, decimal marketPrice,
            DateTime purchaseDate, decimal interestRate, int timePeriod)
            : base(id, name, currency, quantity, purchasePrice, marketPrice, purchaseDate)
        {
            InterestRate = interestRate;
            TimePeriod = timePeriod;
        }

        public override decimal CalculateCurrentValue()
        {
            return PurchasePrice + (PurchasePrice * InterestRate * TimePeriod);
        }
    }

   
    class Portfolio
    {
        private List<FinancialInstrument> instruments = new List<FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (instruments.Any(i => i.Id == instrument.Id))
                throw new Exception("Duplicate Instrument ID");

            instruments.Add(instrument);
        }

        public decimal GetTotalPortfolioValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }

        public void PrintSummary()
        {
            Console.WriteLine("===== PORTFOLIO SUMMARY =====\n");

            var grouped = instruments.GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {
                var totalInvestment = group.Sum(i => i.Quantity * i.PurchasePrice);
                var currentValue = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"Instrument Type: Rs {group.Key}");
                Console.WriteLine($"Total Investment: Rs {totalInvestment}");
                Console.WriteLine($"Current Value: Rs {currentValue}");
                Console.WriteLine($"Profit/Loss: Rs {(currentValue - totalInvestment)}\n");
            }

            Console.WriteLine($"Overall Portfolio Value: Rs {GetTotalPortfolioValue():C}");
        }
    }

   
    internal class Program
    {
        static void Main(string[] args)
        {
            Portfolio portfolio = new Portfolio();

           
            portfolio.AddInstrument(new Equity(1, "INFY", "INR", 100, 1500m, 1650m, DateTime.Now.AddMonths(-6)));
            portfolio.AddInstrument(new Equity(2, "TCS", "INR", 50, 3200m, 3500m, DateTime.Now.AddMonths(-3)));

            
            portfolio.AddInstrument(new MutualFund(3, "SBI Bluechip", "INR", 200, 50m, 65m, DateTime.Now.AddYears(-1)));
            portfolio.AddInstrument(new MutualFund(4, "HDFC Midcap", "INR", 150, 80m, 95m, DateTime.Now.AddMonths(-8)));

           
            portfolio.AddInstrument(new Bond(5, "Govt Bond 2030", "INR", 10, 1000m, 1050m, DateTime.Now.AddYears(-2)));
            portfolio.AddInstrument(new Bond(6, "Corporate Bond XYZ", "INR", 20, 950m, 980m, DateTime.Now.AddYears(-1)));

           
            portfolio.AddInstrument(new FixedDeposit(7, "SBI FD", "INR", 1, 100000m, 100000m,
                DateTime.Now.AddYears(-1), 0.06m, 2));

            portfolio.AddInstrument(new FixedDeposit(8, "HDFC FD", "INR", 1, 200000m, 200000m,
                DateTime.Now.AddMonths(-6), 0.055m, 1));

           
            portfolio.PrintSummary();
        }
    }
}