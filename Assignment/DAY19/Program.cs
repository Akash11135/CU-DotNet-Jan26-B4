namespace DAY19
{


    abstract class Vehicle
    {
       
        public string ModelName { get; set; }
        
        public Vehicle(string ModelName)
        {
            this.ModelName = ModelName;
        }
        abstract public void Move();
        public virtual string GetFuelStatus()
        {
           return "Fuel level is stable...";
        }

        

    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string ModelName):base(ModelName)
        {
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%." ;
        }
        public  override void  Move()
        {
            Console.WriteLine($"{ModelName} is moving using electric power.");
        }
    }


    class HeavyTruck : Vehicle
    {

        public HeavyTruck(string ModelName) : base(ModelName)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }

        //public override void GetFuelStatus()
        //{
        //    Console.WriteLine();
        //}
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string ModelName) : base(ModelName)
        {
        }

        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + "Checking jet fuel reserves...";
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
    }

    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Vehicle[] vehicles = new Vehicle[3]
        //    {
        //        new ElectricCar("Tesla Model S"),
        //        new HeavyTruck("Freightliner Cascadia"),
        //        new CargoPlane("Boeing 747 Freighter")
        //    };
        //    Console.WriteLine("-------------------output-------------------");
        //    for(int i=0; i<vehicles.Length; i++)
        //    {
        //        vehicles[i].Move();
        //        Console.WriteLine(vehicles[i].GetFuelStatus());
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine("-------------------output-------------------");


        //}
    }
}