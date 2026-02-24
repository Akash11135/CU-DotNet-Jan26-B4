using System;

class Program
{
    static void Main()
    {
        string s = "abcdu";
        string vowels = "aeiou";
        string result = "";

        foreach (char c in s)
        {
            if (vowels.Contains(c))
            {
                int idx = vowels.IndexOf(c);
                result += vowels[(idx + 1) % 5];
            }
            else
            {
                char next = (char)(c + 1);
                if (vowels.Contains(next)) next++;
                result += next;
            }
        }

        Console.WriteLine(result); // ecdfa
    }
}