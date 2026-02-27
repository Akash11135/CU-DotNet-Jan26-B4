using System;

class MessageProcessing_DAY8_01
{
    public void process (){

        Console.WriteLine("Enter input : ");
        string input = Console.ReadLine();

        
        string[] parts = input.Split('|');

        string userName = parts[0];
        string rawMessage = parts[1];

       
        string cleanedMessage = rawMessage.Trim().ToLower();

        
        string standardMessage = "login successful";

        bool containsSuccessful = cleanedMessage.Contains("successful");

       
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

        Console.WriteLine($"User     : {userName}");
        Console.WriteLine($"Message  : {cleanedMessage}");
        Console.WriteLine($"Status   : {status}");
    }
        
    
}

class Bank_DAY8_02
{
    public void process()
    {
        Console.WriteLine("Enter input : ");

        string input = Console.ReadLine();
        string[] parts = input.Split('#');

        string taxId = parts[0].Trim().ToLower();
        string userName = parts[1].Trim().ToLower();
        string narration = parts[2].Trim().ToLower();
        while(narration.Contains("  "))
        {
            narration = narration.Replace("  ", " ");
        }
        string category;


        if (narration.Contains("deposit") || narration.Contains("withdrawal")||     narration.Contains("transfer"))
        { 
            category = "STANDARD TRANSACTION";
        }
        else if(narration=="")
        {
            category = "NON-FINANTIAL TRANSACTION";
        }
        else
        {
            category = "CUSTOM TRANSACTION";
        }

        Console.WriteLine("Transaction ID : " + taxId);
        Console.WriteLine("Account Holder : "+userName);
        Console.WriteLine("Narration : "+narration);
        Console.WriteLine("Category : "+category);
    }
}

class Program
{
    
    static void Main()
    {
        MessageProcessing_DAY8_01 obj = new MessageProcessing_DAY8_01();
        obj.process();

        Bank_DAY8_02 n = new Bank_DAY8_02();
        n.process();
    }
}
