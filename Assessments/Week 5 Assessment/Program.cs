//shipment.txt----ship ID , ship name , ship status

namespace Week_5_Assessment
{
    //custom exception.
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message){
        }
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message):base(message) { }
    }

    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        public Shipment(string TrackingId, double Weight, string Destination)
        {
            this.Destination = Destination;
            this.Weight = Weight;
            this.TrackingId = TrackingId;
        }
        public abstract void ProcessShipment();
    }


    class ExpressShipment : Shipment , ILoggable
    {

        public string HeavyLiftTag = "False";

        public string RestrictedZone = "False";

        public bool Reinforced;

        public bool Fragile;

        public bool ShipmentStatus = true;

        public string LogMessage = "";
        public ExpressShipment(string TrackingId, double Weight, string Destination , bool Reinforced , bool Fragile) : base(TrackingId, Weight, Destination) { 
           
            this.Reinforced = Reinforced;
            this.Fragile = Fragile;
        
        }

        //list of unknown locations.
        List<String> UnknownLocations = new List<string> {
          "north pole" , "south pole","unknownisland01","unknownisland02"
        };
        
        //public string Fragile
        public override void ProcessShipment()
        {
            
            string HeavyMessage = "";
            try
            {
                HeavyFreight heavy = new HeavyFreight(TrackingId , Weight , Destination , HeavyLiftTag);
                heavy.ProcessShipment();
                
                if(heavy.LogMessage  != null) HeavyMessage= $"Heavy Permit : {heavy.LogMessage}";

                if (UnknownLocations.Contains(Destination.ToLower()))
                {
                    RestrictedZone = "True";
                    ShipmentStatus = false;
                    throw new InsecurePackagingException($"Restricted zone.{Destination.ToUpper()} is out of dilevery bounds!");
                }

                if(!Reinforced && Fragile)
                {
                    ShipmentStatus = false;

                    throw new InsecurePackagingException($"The package is fragile but not checked as reinforced.");
                }
            }
            catch (RestrictedDestinationException e)
            {
                LogMessage += $"Exception : {e.Message}";
               
            }
            catch (InsecurePackagingException e)
            {
                LogMessage += $"Exception : {e.Message}";
            }
            finally
            {
                Console.WriteLine(HeavyMessage);
                LogMessage = $"Item: Date : {System.DateTime.Now} | TrackingID : {TrackingId} | Weight : {Weight} | Destination : {Destination} | HeavyLiftTag : {HeavyLiftTag} | IsZone : {RestrictedZone} | Fragile : {Fragile} | Reinsforced : {Reinforced}\n";
                
                SaveLog(LogMessage);
                Console.WriteLine($"Processing finished for ID: {TrackingId}\n");

                //Console.WriteLine("---------------------------------------");
                //Console.WriteLine($"Item: TrackingID : {TrackingId} | Weight : {Weight} | Destination : {Destination} | HeavyLiftTag : {HeavyLiftTag} | Zone : {RestrictedZone} | Fragile : {Fragile} | Reinforced : {Reinforced}\n");
                //Console.WriteLine($"Processing finished for ID: {TrackingId}\n");
                //Console.WriteLine($"Shipment status : {ShipmentStatus}");
                //Console.WriteLine("---------------------------------------");


            }

        }

        public void SaveLog(string LogMessage)
        {
            string DirPath = @"D:\college\CAPEGIMINI\assessments\CU-DotNet-Jan26-B4\Assessments\Week 5 Assessment\Shipment\";
            string FilePath = "Shipment_audit.log";
            string FinalPath = Path.Combine(DirPath, FilePath);
            try
            {
                if (!Directory.Exists(DirPath))
                {
                    
                    Directory.CreateDirectory(DirPath);
                }

                if (!File.Exists(FinalPath))
                {
                    Console.WriteLine("File doesnt exist, creating a new file.");
                    File.Create(FinalPath).Close();
                    
                }

                using (StreamWriter sw = new StreamWriter(FinalPath) , append:true) 
                {
                    sw.WriteLine(LogMessage);
                }

                using (StreamReader sr = new StreamReader(FinalPath))
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
            catch (FileNotFoundException e)
            {
                LogMessage += $"Exception : {e.Message}";
                Console.WriteLine("Exception : "+e.Message);
            }
            finally
            {
                Console.WriteLine("Log entry successfully done");
            }
        }

    }
    
    class HeavyFreight : Shipment
    {

        public string LogMessage = "Permitted.";
        public string heavyLiftPermit = "False";
        public HeavyFreight(string TrackingId , double Weight , string Destination, string heavyLiftTag) : base(TrackingId  , Weight , Destination) {
            this.heavyLiftPermit = heavyLiftTag;
        }

        public override void ProcessShipment()
        {
            try {
                if(Weight <= 0)
                {
                    throw new ArgumentOutOfRangeException("Weight cant be 0.");
                }
                if (Weight > 1000.00 && heavyLiftPermit=="False")
                {

                    throw new ArgumentOutOfRangeException("Weight tag needed for permit.");
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                LogMessage = e.Message;
                
            }
        }

        
       
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shipment> ShipmentList = new List<Shipment>();
            ShipmentList.Add(new ExpressShipment("01",100.00 , "Banglore" , true , true));
            ShipmentList.Add(new ExpressShipment("02", 10000.00, "Chandigarh", true,false));
            ShipmentList.Add(new ExpressShipment("03", 10.00, "North Pole", false, false));
            ShipmentList.Add(new ExpressShipment("03", 10.00, "Manglore", false, true));


            foreach (var Shipment in ShipmentList)
            {
                Shipment.ProcessShipment();

            }

        }
    }
}
