namespace Revision
{
    internal class DAY18_01
    {
        class Loan
        {
            public string LoanNumber { get; set; }
            public string CustomerName { get; set; }
            
            public decimal PrincipalAmount { get; set; }

            public int TennureInYears { get; set; }

            public decimal Rate { get; set; }
            public Loan(string LoanNumber  ,string CustomerName , decimal PrincipalAmount , int TennureInYears , decimal Rate )
            {
                this.LoanNumber = LoanNumber;
                this.TennureInYears = TennureInYears;
                this.CustomerName = CustomerName;
                this.PrincipalAmount = PrincipalAmount;
                this.Rate = Rate;
            }

            public decimal CalculateEMI()
            {
                decimal emi = (PrincipalAmount + PrincipalAmount * Rate * TennureInYears / 100);
                return emi;
            }

        }
        
        class HomeLoan : Loan
        {
            
            public HomeLoan(string LoanNumber, string CustomerName, decimal PrincipalAmount, int TennureInYears , decimal Rate) : base(LoanNumber , CustomerName , PrincipalAmount+ (PrincipalAmount*0.01m) , TennureInYears , Rate){ }
            
        }

        class CarLoan : Loan
        {
            public CarLoan(string LoanNumber, string CustomerName, decimal PrincipalAmount, int TennureInYears, decimal Rate) : base(LoanNumber, CustomerName, PrincipalAmount + (15000), TennureInYears, Rate) { }
        }
        //static void Main(string[] args)
        //{
        //    Loan[] loans = new Loan[]
        //    {
        //        new CarLoan("1" , "Akash" , 100000 , 2 , 0.09m),
        //        new CarLoan("2" , "Piyush" , 10000 , 2 , 0.09m),
        //        new HomeLoan("3" , "Aryan" , 500000 , 3 , 0.08m),
        //        new HomeLoan("4" , "Yash" , 700000 , 4 , 0.08m)
        //    };

        //    Console.WriteLine("Details of customer");
        //    Console.WriteLine("---------------------------------------------------------------------------");
        //    Console.WriteLine($"{"Id" , -10} |{"Name",-10}|{"Principal",-10}|{"Rate",-10}|{"Time",-10}|{"EMI",-10} ");
        //    Console.WriteLine("---------------------------------------------------------------------------");

        //    foreach (var i in loans)
        //    {

        //        Console.WriteLine($"{i.LoanNumber,-10} |{i.CustomerName,-10}|{i.PrincipalAmount,-10}|{i.Rate,-10}|{i.TennureInYears,-10}|{i.CalculateEMI(),-10} ") ;
        //    }
        //}
    }

    internal class DAY19_01
    {
        
        abstract class Vehicle
        {
            public string ModelName;
            
            public Vehicle(string ModelName)
            {
                this.ModelName = ModelName;
            }

            public abstract void Move();
            public virtual string GetFuelStatus()
            {
                return "Fuel level is stable.";
            }
        }

        class ElectricCar : Vehicle
        {
            public ElectricCar(string Modelname):base(Modelname){ }

            public override void Move()
            {
                Console.WriteLine($"{ModelName} glides smoothly.");
            }

            public override string GetFuelStatus()
            {
                return $"{ModelName} battery  : 80%";
            }
        }

        class HeavyTruck : Vehicle 
        { 
            public HeavyTruck(string Modelname) : base(Modelname) { }

            public override void Move() {
                Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power. ");
            }

            public override string GetFuelStatus()
            {
                return base.GetFuelStatus();
            }
        }

        class CargoPlane : Vehicle {
            public CargoPlane(string ModelName) : base(ModelName) { }
            public override void Move()
            {
                Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
            }
            public override string GetFuelStatus()
            {
                return base.GetFuelStatus() + "Checking jet fuel reserves...";
            }
        }
        //public static void Main(string[] args)
        //{
        //    Vehicle[] vehicles = new Vehicle[]
        //    {
        //        new ElectricCar("Tesla"),
        //        new HeavyTruck("Monster Truck"),
        //        new CargoPlane("IL-24")
        //    };

        //    foreach (var i in vehicles)
        //    {
        //        Console.WriteLine("--------------");
        //        i.Move();
        //        Console.WriteLine(i.GetFuelStatus());
        //        Console.WriteLine("--------------");
        //    }
        //}
    }

    internal class DAY20
    {
     
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public Flight(string flightNumber, decimal price, TimeSpan duration, DateTime departureTime)
        {
            FlightNumber = flightNumber;
            Price = price;
            Duration = duration;
            DepartureTime = departureTime;
        }

        
        public int CompareTo(Flight other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
            }

        public override string ToString()
        {
            return $"{FlightNumber,-10} | ₹{Price,-8} | {Duration,-10} | {DepartureTime}";
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Duration.CompareTo(y.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }

    class Program
    {
        //static void Main()
        //{
        //    List<Flight> flights = new List<Flight>
        //{
        //    new Flight("AI101", 5000, TimeSpan.FromHours(2.5), DateTime.Today.AddHours(10)),
        //    new Flight("AI202", 4500, TimeSpan.FromHours(3), DateTime.Today.AddHours(6)),
        //    new Flight("AI303", 7000, TimeSpan.FromHours(1.5), DateTime.Today.AddHours(14)),
        //    new Flight("AI404", 4500, TimeSpan.FromHours(2), DateTime.Today.AddHours(8))
        //};

            
        //    Console.WriteLine("\n=== Economy View (Cheapest First) ===");
        //    flights.Sort();
        //    PrintFlights(flights);

        //    Console.WriteLine("\n=== Business Runner View (Shortest First) ===");
        //    flights.Sort(new DurationComparer());
        //    PrintFlights(flights);

 
        //    Console.WriteLine("\n=== Early Bird View (Earliest First) ===");
        //    flights.Sort(new DepartureComparer());
        //    PrintFlights(flights);
        //}

        //static void PrintFlights(List<Flight> flights)
        //{
        //    Console.WriteLine("Flight     | Price    | Duration   | Departure");
        //    Console.WriteLine("-------------------------------------------------------------");

        //    foreach (var f in flights)
        //    {
        //        Console.WriteLine(f);
        //    }
        //}
    }
}

    internal class constvsread
    {
        class Demo
        {
            public readonly int radius;
            public const decimal pi = 3.14m;
            
            public Demo(int value)
            {
                radius = value;

                Console.WriteLine("Area : "+pi*radius*radius);
            }

           
        }

        public static void Main(string[] args)
        {
            Demo d = new Demo(20);
           
        }

    }
}

