using System;
using System.Collections;

namespace DAY24
{
    internal class Program
    {

        //DAY24 exercise 01
        class LegacyDirectory
        {
            public Hashtable ht = new Hashtable();

            public void AddEntry(int Id, string Name)
            {
                ht.Add(Id, Name);
                Console.WriteLine($"Added  ID: {Id}, Name: {Name}");
            }

            public void RemoveEntry(int Id)
            {
                if (ht.ContainsKey(Id))
                {
                    ht.Remove(Id);
                    Console.WriteLine($"Removed employee with ID: {Id}");
                }
                else
                {
                    Console.WriteLine($"Cannot remove. ID {Id} not found.");
                }
            }

            public void Check(int Id)
            {
                if (ht.ContainsKey(Id))
                {
                    Console.WriteLine($"ID {Id} already exists.");
                }
                else
                {
                    ht.Add(Id, "Edward");
                    Console.WriteLine($"ID {Id} not found. Added  Edward");
                }
            }

            public void Search(int Id)
            {
                if (ht.ContainsKey(Id))
                {
                    string Name = (string)ht[Id];
                    Console.WriteLine($"Employee Found  ID: {Id}, Name: {Name}");
                }
                else
                {
                    Console.WriteLine($"No employee found with ID {Id}");
                }
            }

            public void PrintHashTable()
            {
                Console.WriteLine("\nEmployee Directory");
                Console.WriteLine("----------------------------");

                foreach (DictionaryEntry items in ht)
                {
                    Console.WriteLine($"ID: {items.Key} | Name: {items.Value}");
                }
            }
        }


        //DAY 24 exercise 02

        class LeaderBoard
        {

            SortedDictionary<double, string> leaderBoard = new SortedDictionary<double, string>();

            public void Add(double Time, string Name)
            {
                leaderBoard.Add(Time, Name);
                Console.WriteLine("Successfully added : " + Time + "----" + Name);
            }

            public void Remove(double Id)
            {
                leaderBoard.Remove(Id);
                Console.WriteLine($"{Id} Removed Successfully.");
                Console.WriteLine("-------------------------------------");

            }

            public void update(double Time)
            {
                if (leaderBoard.ContainsKey(Time))
                {
                    string Name = leaderBoard[Time];
                    Remove(Time);
                    Console.WriteLine($"Enter new Time  for {Name} : ");
                    double NewTime = Convert.ToDouble(Console.ReadLine());

                    Add(NewTime, Name);

                }
                else
                {
                    Console.WriteLine("Name , Time not found.");
                }
            }

            public void Print()
            {
                Console.WriteLine("----------LEADERBOARD------------");
                foreach (var items in leaderBoard)
                {
                    Console.WriteLine($"Time : {items.Key} <--> Name : {items.Value}");
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Winner : {leaderBoard.First().Key} <-> {leaderBoard.First().Value}");
            }


        }

            static void Main(string[] args)
        {
            LegacyDirectory ld = new LegacyDirectory();
            Console.WriteLine("------------------Exerise - 01-------------------");

            Console.WriteLine("=== Initial Data Entry ===");
            ld.AddEntry(101, "Alice");
            ld.AddEntry(102, "Bob");
            ld.AddEntry(103, "Charlie");
            ld.AddEntry(104, "Diana");

            Console.WriteLine("\n=== Checking Unique ID ===");
            ld.Check(105);

            Console.WriteLine("\n=== Retrieving Employee ===");
            ld.Search(102);

            Console.WriteLine("\n=== Deleting Employee ===");
            ld.RemoveEntry(103);
            Console.WriteLine($"Total Employees Remaining: {ld.ht.Count}");

            Console.WriteLine("\n=== Final Directory ===");
            ld.PrintHashTable();


            Console.WriteLine("------------------Exerise - 01-------------------");

            Console.WriteLine("------------------Exerise - 02-------------------");

            LeaderBoard lb = new LeaderBoard();

            lb.Add(55.24, "SwiftRacer");
            lb.Add(52.10, "SpeedDeamon");
            lb.Add(58.91, "SteadyEddie");
            lb.Add(51.05, "TurboTom");

            Console.WriteLine("-------------------------------------");
            lb.update(55.24);
            Console.WriteLine("-------------------------------------");

            lb.Print();
            Console.WriteLine("------------------Exerise - 02-------------------");

        }
    }
}
