using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    internal class GymMembership
    {
        public double amount()
        {
            double fixedCharges = 1000;
            double tredMill =  300;
            double weightLifting = 500;
            double zumba = 250;
            double gst = 0.05;


            int[] services = new int[4];
            
            for(int i=0; i<4; i++)
            {
                Console.WriteLine("Enter 1 to opt for service " + (i+1) + " else enter 0");
                services[i] = Convert.ToInt32(Console.ReadLine());
            }

            double netAmount = 0.0;

            for (int i = 0; i < 4; i++)
            {
                if (services[i])
            }
            return 0.0;
        }
    }
}
