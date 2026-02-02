using EveryDayCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDayCodes
{

    class OLADriver
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string VehicleNumber { get; set; }

        List<Rides> rides = new List<Rides>();

        public OLADriver(string name, int id, string vehicleNumber)
        {
            Name = name;
            Id = id;
            VehicleNumber = vehicleNumber;
        }

       
    }

    class Rides
    {
           public int RideId { get; set; }
           public string Pickup { get; set; }
           public string Drop { get; set; }
           
           public int TotalFare = 0;

        public Rides(int RideId, string Pickup, string Drop, int TotalFare)
            {
                this.RideId = RideId;
                this.Pickup = Pickup;
                this.Drop = Drop;
                this.TotalFare = TotalFare;
            }
        }
    }

   

    internal class OLA
    {

        public static void Main()
        {


            OLADriver driver1 = new OLADriver("driver1", 1, "KA01AB1234");
            driver1.AddRide("driver1", new Rides(101, "LocationA", "LocationB", 500));
            driver1.AddRide("driver1", new Rides(102, "LocationC", "LocationD", 700));
            driver1.AddRide("driver1", new Rides(102, "LocationC", "LocationD", 700));
            OLADriver driver2 = new OLADriver("driver2", 2, "KA02CD5678");
            driver2.AddRide("driver2", new Rides(101, "LocationA", "LocationB", 600));
            driver2.AddRide("driver2", new Rides(102, "LocationC", "LocationD", 800));
        
    }

}


//ouput
//driver1
//-------
//Rides
//------
// - RideId: 101, Pickup: "LocationA", Drop: "LocationB"
// - RideId: 102, Pickup: "LocationC", Drop: "LocationD"

//Total fare = rs x
//==============================
//driver2: Rides
// - RideId: 101, Pickup: "LocationA", Drop: "LocationB"
// - RideId: 102, Pickup: "LocationC", Drop: "LocationD"
//Total fare = rs x
