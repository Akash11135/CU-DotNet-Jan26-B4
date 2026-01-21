using System;

class Program
{
    static void Main()
    {
        // Single input read
        string input = Console.ReadLine();

        // Split username and message
        string[] parts = input.Split('|');

        string userName = parts[0];
        string rawMessage = parts[1];

        // 1. Clean the login message
        string cleanedMessage = rawMessage.Trim().ToLower();

        // Standard message
        string standardMessage = "login successful";

        // 2. String search
        bool containsSuccessful = cleanedMessage.Contains("successful");

        // 3 & 4. Business rules
        string status;

        if (!containsSuccessful)
        {
            status = "LOGIN FAILED";
        }
        else if (cleanedMessage.Equals(standardMessage))
        {
            status = "LOGIN SUCCESS";
        }
        else
        {
            status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
        }

        // 5. Formatted output
        Console.WriteLine($"User     : {userName}");
        Console.WriteLine($"Message  : {cleanedMessage}");
        Console.WriteLine($"Status   : {status}");
    }
}
