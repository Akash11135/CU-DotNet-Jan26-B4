using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        class Item
        {
            public string Name { get; set; }
            public double Weight { get; set; }
            public string Category { get; set; }

            public Item(string Name, double Weight, string Category)
            {
                this.Name = Name;
                this.Weight = Weight;
                this.Category = Category;
            }
        }

        class Container
        {
            public string ContainerId { get; set; }
            public List<Item> Items { get; set; }

            public Container(string ContainerId, List<Item> Items)
            {
                this.ContainerId = ContainerId;
                this.Items = Items;
            }
        }

       
        class CargoHelper
        {
            public static List<string> FindHeavyContainers(List<List<Container>> cargoBay, double weight)
            {
                return cargoBay?
                    .Where(r => r != null)
                    .SelectMany(r => r)
                    .Where(c => c?.Items != null && c.Items.Sum(i => i?.Weight ?? 0) > weight)
                    .Select(c => c.ContainerId)
                    .ToList() ?? new List<string>();

                //return cargoBay.SelectMany(r => r).Where(c => c.Items.Sum(i => i?.Weight) > weight).Select(c => c.ContainerId).ToList()??new List<string>();
            }

            public static Dictionary<string, int> GetItemCountsByCategory(List<List<Container>> cargoBay)
            {
                return cargoBay?
                    .Where(r => r != null)
                    .SelectMany(r => r)
                    .Where(c => c?.Items != null)
                    .SelectMany(c => c.Items)
                    .Where(i => i != null && i.Category != null)
                    .GroupBy(i => i.Category)
                    .ToDictionary(g => g.Key, g => g.Count())
                    ?? new Dictionary<string, int>();
            }

         
            public static List<Item> FlattenAndSortShipment(List<List<Container>> listContainers)
            {
                return listContainers?
                    .Where(r => r != null)
                    .SelectMany(r => r)
                    .Where(c => c?.Items != null)
                    .SelectMany(c => c.Items)
                    .Where(i => i != null && i.Name != null)
                    .GroupBy(i => i.Name)              // remove duplicates
                    .Select(g => g.First())
                    .OrderBy(i => i.Category)          // sort by category
                    .ThenByDescending(i => i.Weight)   // then by weight desc
                    .ToList()
                    ?? new List<Item>();
            }
        }

        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
            {
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"),
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>())
                },

                new List<Container>()
            };

            // ✅ CALL METHODS

            var heavy = CargoHelper.FindHeavyContainers(cargoBay, 20);
            Console.WriteLine("Heavy Containers:");
            heavy.ForEach(Console.WriteLine);

            var categories = CargoHelper.GetItemCountsByCategory(cargoBay);
            Console.WriteLine("\nCategory Counts:");
            foreach (var kv in categories)
                Console.WriteLine($"{kv.Key}: {kv.Value}");

            var sorted = CargoHelper.FlattenAndSortShipment(cargoBay);
            Console.WriteLine("\nFlattened & Sorted Items:");
            foreach (var i in sorted)
                Console.WriteLine($"{i.Name} | {i.Category} | {i.Weight}");
        }
    }
}