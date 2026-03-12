using System;
using System.Collections.Generic;
using System.Linq;

class Item
{
    public string Name;
    public double Weight;
    public string Category;

    public Item(string name, double weight, string category)
    {
        Name = name;
        Weight = weight;
        Category = category;
    }
}

class Container
{
    public string ContainerID;
    public List<Item> Items;

    public Container(string id, List<Item> items)
    {
        ContainerID = id;
        Items = items;
    }
}

class CargoManager
{
    private List<List<Container>> cargoBay;

    public CargoManager(List<List<Container>> cargoBay)
    {
        this.cargoBay = cargoBay;
    }

    // Task A
    public List<string> FindHeavyContainers(double weightThreshold)
    {
        return cargoBay
            .Where(row => row != null)
            .SelectMany(row => row)
            .Where(c => c.Items.Sum(i => i.Weight) > weightThreshold)
            .Select(c => c.ContainerID)
            .ToList();
    }

    // Task B
    public Dictionary<string, int> GetItemCountsByCategory()
    {
        return cargoBay
            .Where(row => row != null)
            .SelectMany(row => row)
            .SelectMany(c => c.Items)
            .GroupBy(i => i.Category)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    // Task C
    public List<Item> FlattenAndSortShipment()
    {
        return cargoBay
            .Where(row => row != null)
            .SelectMany(row => row)
            .SelectMany(c => c.Items)
            .GroupBy(i => i.Name)
            .Select(g => g.First())
            .OrderBy(i => i.Category)
            .ThenByDescending(i => i.Weight)
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        var cargoBay = new List<List<Container>>
        {
            new List<Container>
            {
                new Container("C101", new List<Item>{
                    new Item("Server Rack",45,"Tech"),
                    new Item("Laptop",2,"Tech")
                }),
                new Container("C102", new List<Item>{
                    new Item("Apple",0.2,"Food"),
                    new Item("Milk",1,"Food")
                })
            },
            new List<Container>
            {
                new Container("C103", new List<Item>{
                    new Item("Table",15,"Furniture"),
                    new Item("Mirror",12,"Decor")
                })
            }
        };

        CargoManager manager = new CargoManager(cargoBay);

        Console.WriteLine("Heavy Containers:");
        foreach (var id in manager.FindHeavyContainers(40))
            Console.WriteLine(id);

        Console.WriteLine("\nCategory Counts:");
        var counts = manager.GetItemCountsByCategory();
        foreach (var c in counts)
            Console.WriteLine($"{c.Key} : {c.Value}");

        Console.WriteLine("\nFlattened Shipment:");
        var items = manager.FlattenAndSortShipment();
        foreach (var i in items)
            Console.WriteLine($"{i.Category} - {i.Name} - {i.Weight}");
    }
}