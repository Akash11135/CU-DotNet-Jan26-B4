using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EveryDayCodes
{
    class Game
    {
       

       
        public  void GameFunction(string word)
        {

            word.ToUpper();

            char[] wordArray = word.ToCharArray();
            int[] trackWord = new int[wordArray.Length];

            int Lives = 6;
            
            List<char> guessed = new List<char>();

            int cnt = 0;
            
            while (Lives > 0)
            {


                if (cnt == word.Length)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Yay! Your'e Saved!!");
                    Console.WriteLine("-----------------------------------");
                    break;

                }

                

                Console.WriteLine("-----------------------------------");
                Console.Write("WORD : " );

                for(int i=0; i<wordArray.Length; i++)
                {
                    if (trackWord[i] != 0)
                    {
                        Console.Write($"{wordArray[i]} ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }

                //guessed logic
                Console.WriteLine("\n");
                Console.WriteLine("Guessed : ");
                
                foreach(var guess in guessed)
                {
                    Console.Write(guess+",  "); 
                }

                Console.WriteLine("\n");


                //Lives remaining Login
                Console.WriteLine("Lives Remaining : "+Lives);
                Console.WriteLine("Guess a letter : ");

                //Guessed List Loginc
                char enter = Convert.ToChar(Console.ReadLine().ToUpper());


                if (guessed.Contains(enter))
                {
                    Console.WriteLine("you've already guessed it.");

                }
                else
                {
                    guessed.Add(enter);
                }

                //track Array Login
                if (wordArray.Contains(enter))
                {
                    int startIdx = 0;
                    int cntIdx = 0;
                    int idx = Array.IndexOf(wordArray, enter , startIdx);
                    if (trackWord[idx] != 1 && cntIdx<2)
                    {
                        trackWord[idx]++;
                        cntIdx++;
                    }
                    Console.WriteLine("Good choice!");
                    cnt++;
                }
                else
                {
                    Console.WriteLine("Nope! That's not the word.");
                    Lives--;

                }
                if (Lives == 0)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Nooo! Your'e Hanged!!");
                    Console.WriteLine("-----------------------------------");
                    break;
                }
            }

        }
        

        public void Linq(int[] arr)
        {
            var maxMarks = arr.Where(m=> m>10);    //m => m > 80   This is called a lambda expression in C#.
            
            
            //select is used to transform.

            int[] squares = arr.Select(n => n * n).ToArray();

            foreach (var marks in maxMarks)
            {
                Console.WriteLine("Marks : "+marks);
            }

            var DescMarks = arr.Where(m => m > 50).OrderByDescending(m=>m);
            foreach (var marks in DescMarks)
            {
                Console.WriteLine(marks);
            }
        }
             
        public void FileHandeling()
        {
            
        }

    }
    
    
    internal class Hangman
    {
        public static Random random = new Random();
        //static void Main(string[] args)
        //{

        //    Game game = new Game();

        //    //game.GameFunction("ELEPHANT");
        //    game.FileHandeling();


        //}

    }
}
