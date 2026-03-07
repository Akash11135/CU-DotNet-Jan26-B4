using System;
using System.Collections.Generic;

class Hangman
{
    static void Main()
    {
        string[] words = { "computer", "programming", "hangman", "developer", "keyboard", "internet" };
        Random rand = new Random();
        string word = words[rand.Next(words.Length)];
        HashSet<char> guessed = new HashSet<char>();
        int attempts = 6;

        while (attempts > 0)
        {
            bool won = true;

            Console.Write("\nWord: ");
            foreach (char c in word)
            {
                if (guessed.Contains(c))
                    Console.Write(c + " ");
                else
                {
                    Console.Write("_ ");
                    won = false;
                }
            }

            if (won)
            {
                Console.WriteLine("\nYou won!");
                return;
            }

            Console.WriteLine("\nAttempts left: " + attempts);
            Console.Write("Guess a letter: ");
            char guess = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!guessed.Contains(guess))
            {
                guessed.Add(guess);
                if (!word.Contains(guess))
                    attempts--;
            }
        }

        Console.WriteLine("\nYou lost! The word was: " + word);
    }
}