using System.Diagnostics;
using System.Threading.Tasks;

namespace async_await
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> res = new List<string>();
            Stopwatch watch = new Stopwatch();

            var coffee = MakeCoffee();
            var toast = MakeToast();
            var omelett = MakeOmelett();

            Console.WriteLine("Started making breakfast...");
            watch.Start();
            res.Add(await  coffee);
            res.Add(await toast);
            res.Add(await omelett);


            foreach(var i in res)
            {
                Console.WriteLine(i);
            }
            watch.Stop();
            Console.WriteLine("Breakfast compeleted.Time : "+watch.Elapsed);
        }

       static async Task<string> MakeCoffee()
        {
            Console.WriteLine("coffee making started.");
            await Task.Delay(2000);
            return "coffee done...👍";
        }

        static async Task<string> MakeToast()
        {
            Console.WriteLine("Toast making started.");
            await Task.Delay(4000);
            return "Toast done...👍";
        }

        static async Task<string> MakeOmelett()
        {
            Console.WriteLine("Omelett making started.");
            await Task.Delay(3000);
            return "Omelett done...👍";
        }
    }
}
