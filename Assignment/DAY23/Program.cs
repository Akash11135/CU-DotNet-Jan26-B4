namespace DAY23
{
    internal class Program
    {

        class InvalidStudentAgeException : Exception
        {
            public InvalidStudentAgeException(string message) : base(message) { }
        }

        class InvalidStudentNameException : Exception
        {
            public InvalidStudentNameException(string message) : base(message) { }
        }


        static void Main(string[] args)
        {

            static void LogException(Exception e)
            {
                Console.WriteLine("Trace : " + e.StackTrace);
                Console.WriteLine("Message : " + e.Message);
            }

            static void PrintInnerException(Exception e)
            {
                Console.WriteLine("Trace : " + e.StackTrace);
                Console.WriteLine("Message : " + e.Message);

                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner Exception : " + e.InnerException.Message);
                }
            }

            // Division builtin exception
            try
            {
                int a;
                Console.WriteLine("Enter integer 1 : ");
                a = Convert.ToInt32(Console.ReadLine());
                int b;
                Console.WriteLine("Enter integer 2 : ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Division : " + a / b);
            }
            catch (DivideByZeroException e)
            {
                LogException(e);
            }
            finally
            {
                Console.WriteLine("Operation compeleted");
            }


            //Check integer format exception.
            try
            {
                int a;
                Console.WriteLine("Enter integer 1 : ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Given number : " + a);
            }
            catch (FormatException e)
            {
                LogException(e);
            }
            finally
            {
                Console.WriteLine("Operation compeleted");
            }

            // array bounds exception.
            try
            {
                int[] arr = { 1, 2, 3, 4 };
                int idx;
                Console.WriteLine("Enter the index to access");
                idx = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Number at index {idx} is {arr[idx]}");
            }
            catch (IndexOutOfRangeException e)
            {
                LogException(e);
            }
            finally
            {
                Console.WriteLine("Operation compeleted");
            }

            //Custom exception for student name.
            try
            {
                int age;
                Console.WriteLine("Enter student age : ");
                age = int.Parse(Console.ReadLine());
                Console.WriteLine("Age of student : " + age);

                if (age < 18 || age > 60)
                {
                    throw new InvalidStudentAgeException("Invalid age of the student.");
                }
            }
            catch (InvalidStudentAgeException e)
            {
                LogException(e);
            }
            catch (FormatException e)
            {
                LogException(e);
            }
            finally
            {
                Console.WriteLine("Operation ");
            }

            //custom student name exception _ inner exception.
            try
            {
                string name;
                Console.WriteLine("Enter the name of student : ");
                name = Console.ReadLine();
                Console.WriteLine("Name of the student : " + name);

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new InvalidStudentNameException("name cant be empty");
                }
            }
            catch (InvalidStudentNameException ex)
            {
                Exception e = new Exception("Exception related to name issue of student", ex);
                PrintInnerException(e);
            }
        }
    }
}
