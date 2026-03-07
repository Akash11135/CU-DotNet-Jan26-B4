class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
    public string City { get; set; }
}

class Course
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string CourseName { get; set; }
}

internal class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var students = new List<Student>
                {
                    new Student{ Id=1, Name="Amit", Age=21, Marks=85, City="Delhi"},
                    new Student{ Id=2, Name="Riya", Age=19, Marks=92, City="Mumbai"},
                    new Student{ Id=3, Name="Karan", Age=22, Marks=75, City="Delhi"},
                    new Student{ Id=4, Name="Sneha", Age=20, Marks=88, City="Pune"},
                };

        var courses = new List<Course>
                {
                    new Course{ Id=1, StudentId=1, CourseName="C#"},
                    new Course{ Id=2, StudentId=2, CourseName="Java"},
                    new Course{ Id=3, StudentId=1, CourseName="SQL"},
                };


        var oddNumbers = numbers.Where(x => x % 2 != 0);
        var evenNumbers = numbers.Where(x => x % 2 == 0).OrderByDescending(x=>x);


        var studentsDelhi = students.Where(x => x.City  == "Delhi").Select(x=>x.Name);


        var distinctCities = students.Select(x => x.City).Distinct();

        var studentNameAndCity = students.Select(x => new {x.Name , x.City});

        //Console.WriteLine(string.Join(stu));

        //foreach(var s in studentNameAndCity)
        //{
        //    Console.WriteLine(s.Name+" , "+s.City);
        //}


        //Console.WriteLine(string.Join(", ", distinctCities));

        //Console.WriteLine(string.Join(", " , studentsDelhi));

        //foreach(var i in distinctCities)
        //{
        //    Console.WriteLine(i.City);
        //}

        //Console.WriteLine(studentsDelhi.Se);
        //foreach (var i in studentsDelhi)
        //{
        //    Console.WriteLine(i.Name);
        //}

        //Console.WriteLine(string.Join("," , studentsDelhi));
        //Console.WriteLine("Hello, LINQ!");



        var studentDet = students.Where(x => x.Marks > 80).GroupBy(x => x.City).SelectMany(g=>g);

        //foreach(var s in studentDet)
        //{
        //    Console.WriteLine(s.Name+" "+s.Marks+" "+s.City);
        //}

        var studentDetails = students.GroupJoin(courses,
                            s => s.Id, c => c.StudentId,
                            (s, c) => new
                            {
                                s.Id,
                                s.Name,
                                hasId = c.Any() // boolean
                            }
        );
        
        foreach(var s in studentDetails)
        {
            Console.WriteLine(s.Name+" "+s.Id+" "+s.hasId);
        }

        var cityStudCnt = students.GroupBy(c => c.City).Select(g => new
        {
            city = g.Key,
            count = g.Count(),
            totalMarks = g.Sum(x => x.Marks)

        });

        Console.WriteLine(string.Join("\n", cityStudCnt));

    }
}