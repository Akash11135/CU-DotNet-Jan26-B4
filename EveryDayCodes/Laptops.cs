using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDayCodes
{
    class Laptop
    {
        public int LaptopId { get; set; }
        public string Company  { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }

        public Laptop(int LaptopId , string Company , string ModelName , decimal Price)
        {
            this.LaptopId = LaptopId;
            this.Company = Company; 
            this.ModelName = ModelName;
            this.Price = Price;
        }


        public override string ToString()
        {
            return $"Laptop id :{LaptopId} , Comany : {Company} , ModelName : {ModelName} , Price : {Price}";
        }
    }


    internal class Laptops
    {
        
       

       
    }
}
