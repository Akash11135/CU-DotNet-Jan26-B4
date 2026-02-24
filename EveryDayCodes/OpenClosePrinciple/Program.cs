
//open - close principle
//adding payment + basicTax(based upon type of payment)



namespace OpenClosePrinciple
{

    class PhonePe: IPayment
    {

        decimal tax = 0.05m;

        public decimal CalculateTotalBill(decimal totalBill )
        {
            return totalBill + tax * totalBill;
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPayment payment = new PhonePe();
            Console.WriteLine($"Total bill : {payment.CalculateTotalBill(1000.00m)}");
        }
    }
}
