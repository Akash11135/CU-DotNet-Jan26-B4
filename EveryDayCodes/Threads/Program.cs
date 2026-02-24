namespace Week6Learnings
{

    public class BankAccount
    {
        Object lockObject = new Object();

        public int Balance { get; set; }

        public BankAccount(int initialBal)
        {
            Balance = initialBal;
        }
        public void Withdraw(int amt, string tname)
        {
            lock (lockObject)
            {

                int amount = (int)amt;
                if (Balance >= amount)
                {
                    Console.WriteLine("Withraw can be done...");
                    Thread.Sleep(2000);
                    Balance -= amount;
                    Console.WriteLine($"Transaction successful for {tname}");
                }
                else
                {
                    Console.WriteLine($"No sufficient balance available for {tname}");
                }
            }
        }

        public void Display(object x)
        {
            Console.WriteLine(x.ToString());
        }

    }
    internal class Demo11BankTransactionsThreads
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(1000);

            ThreadStart ts1 =
                new ThreadStart(() => account1.Withdraw(750, "thread1"));

            Thread transaction1 = new Thread(ts1);
            Thread transaction2 = new Thread(() => account1.Withdraw(750, "thread2"));

            transaction1.Start();
            transaction2.Start();

            transaction1.Join();
            transaction2.Join();

            // sequential processing
            //account1.Withdraw(750);
            //account1.Withdraw(750);

            Console.WriteLine(account1.Balance);

        }
    }
}