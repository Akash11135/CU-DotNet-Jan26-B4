namespace DAY20
{
    internal class Program
    {
        class Flight : IComparable<Flight>
        {
            public string FlightNumber { get; set; }
            public decimal Price { get; set; }
            public TimeSpan Duration { get; set; }
            public DateTime DepartureTime { get; set; }

            
            //default sorting using price.
            public int CompareTo(Flight other)
            {
                if (other == null) return -1;

                return this.Price.CompareTo(other.Price);
            }


        }

        class DurationComparer : IComparer<Flight>
        {
            public int Compare(Flight x , Flight y)
            {
                if(x==null && y== null) return 0;
                if (x == null) return 1;  // to avoid null object comparison issues.
                return x.Duration.CompareTo(y.Duration);
            }
        }

        class DepartureComparer : IComparer<Flight>
        {
            public int Compare(Flight x, Flight y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return 1;   // to avoid null object comparison issues.
                return x.DepartureTime.CompareTo(y.DepartureTime);
            }
        }

        static void Main(string[] args)
        {

            List<Flight> flights = new List<Flight>
            {
                new Flight
                {
                    FlightNumber = "SH101",
                    Price = 4500m,
                    Duration = TimeSpan.FromHours(2.5),
                    DepartureTime = DateTime.Today.AddHours(9)
                },
                new Flight
                {
                    FlightNumber = "SH205",
                    Price = 3200m,
                    Duration = TimeSpan.FromHours(1.8),
                    DepartureTime = DateTime.Today.AddHours(6)
                },
                new Flight
                {
                    FlightNumber = "SH330",
                    Price = 5200m,
                    Duration = TimeSpan.FromHours(3),
                    DepartureTime = DateTime.Today.AddHours(11)
                }
            };

            flights.Sort();
            Console.WriteLine("Economy View (By Price):");
            PrintFlights(flights);

            // Business Runner View (Shortest duration)
            flights.Sort(new DurationComparer());
            Console.WriteLine("\nBusiness Runner View (By Duration):");
            PrintFlights(flights);

            // Early Bird View (Earliest departure)
            flights.Sort(new DepartureComparer());
            Console.WriteLine("\nEarly Bird View (By Departure Time):");
            PrintFlights(flights);


          
            //need to be static as its under a static main method.
            static void PrintFlights(List<Flight> flights){
                foreach(var flight in flights)
                {
                    Console.WriteLine(
                $"{flight.FlightNumber} | ₹{flight.Price} | {flight.Duration} | {flight.DepartureTime:t}"
                    );
                }
            }
        }
    }
}
