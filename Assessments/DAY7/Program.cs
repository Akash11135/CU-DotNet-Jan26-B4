namespace day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            string name;
            Console.WriteLine("Enter the age and name : ");
            age = int.Parse(Console.ReadLine());
            name = Console.ReadLine();
            if (age >= 18)
            {
                Console.WriteLine($"Hi {name} , you're Eligible to vote.");
            }
            else
            {
                Console.WriteLine($"Hi {name}, you're Not eligible to vote.");
            }
        }
    }
}
