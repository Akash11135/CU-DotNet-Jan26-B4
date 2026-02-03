abstract class UtilityBill
{
    public int ConsumerId { get; set; }
    public string ConsumerName { get; set; }
    public decimal UnitsConsumed { get; set; }
    public decimal RatePerUnit { get; set; }


    //use protected constructor to prevent direct instantiation or hiding in OOP's
    protected UtilityBill(int consumerId, string consumerName, decimal ratePerUnit, decimal unitsConsumed)
    {
        ConsumerId = consumerId;
        ConsumerName = consumerName;
        RatePerUnit = ratePerUnit;
        UnitsConsumed = unitsConsumed;
    }

    public abstract decimal CalculateBillAmount();

    public virtual decimal CalculateTax(decimal billAmount)
    {
        return billAmount * 0.05M; // 5% default tax
    }

    public void PrintBill()
    {
        decimal billAmount = CalculateBillAmount();
        decimal tax = CalculateTax(billAmount);
        decimal total = billAmount + tax;

        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Consumer ID   : {ConsumerId}");
        Console.WriteLine($"Name          : {ConsumerName}");
        Console.WriteLine($"Units Consumed: {UnitsConsumed}");
        Console.WriteLine($"Bill Amount   : {billAmount}");
        Console.WriteLine($"Tax           : {tax}");
        Console.WriteLine($"Total Payable : {total}");
        Console.WriteLine("-----------------------------------");
    }
}

class ElectricityBill : UtilityBill
{
    public ElectricityBill(int id, string name, decimal rate, decimal units)
        : base(id, name, rate, units) { }

    public override decimal CalculateBillAmount()
    {
        decimal billAmount = UnitsConsumed * RatePerUnit;

        if (UnitsConsumed > 300)
        {
            billAmount += billAmount * 0.10M; // 10% surcharge
        }

        return billAmount;
    }
}

class WaterBill : UtilityBill
{
    public WaterBill(int id, string name, decimal rate, decimal units)
        : base(id, name, rate, units) { }

    public override decimal CalculateBillAmount()
    {
        return UnitsConsumed * RatePerUnit;
    }

    public override decimal CalculateTax(decimal billAmount)
    {
        return billAmount * 0.02M; // 2% tax
    }
}

class GasBill : UtilityBill
{
    public GasBill(int id, string name, decimal rate, decimal units)
        : base(id, name, rate, units) { }

    public override decimal CalculateBillAmount()
    {
        return (UnitsConsumed * RatePerUnit) + 150;
    }

    public override decimal CalculateTax(decimal billAmount)
    {
        return 0; // No tax
    }


    internal class DAY19_02
    {
        static void Main(string[] args)  //remove main from program.cs if running this file/Or add this login into program.cs main function.
        {
            List<UtilityBill> bills = new List<UtilityBill>
        {
            new ElectricityBill(1, "John Doe", 0.12M, 350),
            new WaterBill(2, "Jane Smith", 0.05M, 150),
            new GasBill(3, "Bob Johnson", 0.08M, 200)
        };

            foreach (var items in bills)
            {
                items.PrintBill();
            }

        }
    }
}
