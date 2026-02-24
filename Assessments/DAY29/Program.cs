using System;
using System.Collections.Generic;

    
namespace DAY29
{
    abstract class Appliance
    {
        public string ModelName { get; set; }
        public int PowerConsumption { get; set; }

        public Appliance(string model, int power)
        {
            ModelName = model;
            PowerConsumption = power;
        }

        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }
    }


    interface ITimer
    {
        void SetTimer(int time);
    }

    interface IWiFiEnabled
    {
        void ConnectToWiFi();
    }

    class Microwave : Appliance, ITimer
    {
        public Microwave(string model, int power) : base(model, power) { }

        public void SetTimer(int time)
        {
            Console.WriteLine($"{ModelName}: Timer set for {time} minutes.");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Heating food quickly using microwaves.");
        }
    }


    class Oven : Appliance, ITimer, IWiFiEnabled
    {
        public Oven(string model, int power) : base(model, power) { }

        public void SetTimer(int time)
        {
            Console.WriteLine($"{ModelName}: Timer set for {time} minutes.");
        }

        public void ConnectToWiFi()
        {
            Console.WriteLine($"{ModelName}: Connected to WiFi.");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName}: Preheating oven...");
        }

        public override void Cook()
        {
            Preheat();
            Console.WriteLine($"{ModelName}: Baking food evenly.");
        }
    }

    class AirFryer : Appliance
    {
        public AirFryer(string model, int power) : base(model, power) { }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Cooking crispy food using hot air.");
        }
    }


    class Program
    {
        static void Main()
        {
            List<Appliance> appliances = new List<Appliance>()
        {
            new Microwave("MW-101", 1200),
            new Oven("OV-202", 2000),
            new AirFryer("AF-303", 1500)
        };

            Console.WriteLine("=== Cooking Process ===");
            foreach (var device in appliances)
            {
                device.Cook();
            }

            Console.WriteLine("\n=== WiFi Check ===");
            foreach (var device in appliances)
            {
                if (device is IWiFiEnabled wifiDevice)
                {
                    wifiDevice.ConnectToWiFi();
                }
                else
                {
                    Console.WriteLine($"{device.ModelName}: No WiFi support.");
                }
            }
        }
    }
}
