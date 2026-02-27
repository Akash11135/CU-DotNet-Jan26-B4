using System.Diagnostics;

namespace DAY41_FinancialPortfolioMgmt
{
    internal class Program
    {
        //1 equity 10 100 
        abstract class FinantialInstrument
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int PurchasePrice { get; set; }
            public int MarketPrice { get; set;  }


            public abstract decimal CalculateCurrentValue();

            public virtual string GetInstrumentSummary()
            {
                return "Summary Details : ";
            }

        }

        class Equity : FinantialInstrument
        {
            public override decimal CalculateCurrentValue()
            {
                decimal currVal = Quantity * Price;
                return currVal;
            }
            public override string GetInstrumentSummary()
            {
                return $"{base.GetInstrumentSummary()} [Equity , {CalculateCurrentValue()}] ";
            }
        }

        class FixedDeposite : FinantialInstrument 
        {
            public decimal intrestRate = 0.03m;
            public override decimal CalculateCurrentValue()
            {
                decimal currVal = Quantity * Price;
                return currVal;
            }
            public override string GetInstrumentSummary()
            {
                return $"{base.GetInstrumentSummary()} [Equity , {CalculateCurrentValue()}] ";
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
