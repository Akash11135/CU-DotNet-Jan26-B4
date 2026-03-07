using System;

namespace HeightAddition
{
    //DAY15-01
    class Height
    {
        public int Feet { get; set; }
        public double Inches { get; set; }

        // Default constructor
        public Height()
        {
            Feet = 0;
            Inches = 0.0;
        }

        // Parameterized constructor
        public Height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        // Method to add heights
        public Height AddHeights(Height h2)
        {
            int totalFeet = this.Feet + h2.Feet;
            double totalInches = this.Inches + h2.Inches;

            if (totalInches >= 12)
            {
                totalFeet += (int)(totalInches / 12);
                totalInches = totalInches % 12;
            }

            return new Height(totalFeet, totalInches);
        }

        // Override ToString
        public override string ToString()
        {
            return $"Height - {Feet} feet {Inches:F1} inches";
        }
    }

   
    //DAY15-02
   

public class Order
    {
       
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private DateTime _orderDate;
        private string _status;
        private bool _discountApplied;

       
        public Order()
        {
            _orderDate = DateTime.Now;
            _status = "NEW";
        }

        
        public Order(int orderId, string customerName)
        {
            _orderId = orderId;
            CustomerName = customerName; // validation through property
            _orderDate = DateTime.Now;
            _status = "NEW";
        }

        
        public int OrderId
        {
            get { return _orderId; }
        }

        
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Customer name cannot be empty");

                _customerName = value;
            }
        }

       
        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }


        public void AddItem(decimal price)
        {
            if (price < 0)
                throw new Exception("Price cannot be negative");

            _totalAmount += price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_discountApplied)
                throw new Exception("Discount already applied");

            if (percentage < 1 || percentage > 30)
                throw new Exception("Discount must be between 1 and 30");

            decimal discount = (_totalAmount * percentage) / 100;
            _totalAmount -= discount;

            _discountApplied = true;
        }

        public string GetOrderSummary()
        {
            return $"Order Id: {_orderId}\nCustomer: {_customerName}\nTotal Amount: {_totalAmount}\nStatus: {_status}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Height person1 = new Height(5, 6.5);
            Height person2 = new Height(5, 7.5);

            Height totalHeight = person1.AddHeights(person2);

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(totalHeight);

            Console.ReadLine();

            //..............02................
            // Using Parameterized Constructor
            Order order1 = new Order(101, "Rahul");
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);

            Console.WriteLine(order1.GetOrderSummary());

            Console.WriteLine("----------------------");

            // Using Default Constructor
            Order order2 = new Order();
            order2.CustomerName = "Akash";
            order2.AddItem(1000);
            order2.ApplyDiscount(20);

            Console.WriteLine(order2.GetOrderSummary());
        }
    }
}
