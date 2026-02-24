using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    private HashSet<Person> friends = new HashSet<Person>();

    public Person(string name) { Name = name; }

    public void AddFriend(Person p)
    {
        if (p == this) return; 
        if (friends.Add(p))
            p.friends.Add(this); 
    }

    public IEnumerable<Person> GetFriends() => friends;
}

class SocialNetwork
{
    List<Person> users = new List<Person>();

    public void Add(Person p) => users.Add(p);

    public void ShowNetwork()
    {
        foreach (var u in users)
        {
            var names = string.Join(", ", u.GetFriends().Select(f => f.Name));
            Console.WriteLine($"{u.Name} -> {names}");
        }
    }
}

class Program
{
    static void Main()
    {
        var a = new Person("Aman");
        var b = new Person("Rahul");
        var c = new Person("Neha");

        a.AddFriend(b);
        a.AddFriend(c);

        var net = new SocialNetwork();
        net.Add(a); net.Add(b); net.Add(c);

        net.ShowNetwork();
    }
}