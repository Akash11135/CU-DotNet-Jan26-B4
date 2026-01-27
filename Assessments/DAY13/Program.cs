using System;

class GymMembership
{
    // Method to calculate monthly membership amount
    public static decimal CalculateMembershipAmount(
        bool treadMill,
        bool weightLifting,
        bool zumba)
    {
        decimal total = 1000; // Fixed monthly charges
        bool anyServiceSelected = false;

        if (treadMill)
        {
            total += 300;
            anyServiceSelected = true;
        }

        if (weightLifting)
        {
            total += 500;
            anyServiceSelected = true;
        }

        if (zumba)
        {
            total += 250;
            anyServiceSelected = true;
        }

        // Penalty if no service selected
        if (!anyServiceSelected)
        {
            total += 200;
        }

        // GST 5%
        decimal gst = total * 0.05m;
        total += gst;

        return total;
    }
}

class LineDisplay
{
    // 1. No parameter → 40 '-'
    public static void DisplayLine()
    {
        Console.WriteLine(new string('-', 40));
    }

    // 2. One character → 40 times
    public static void DisplayLine(char ch)
    {
        Console.WriteLine(new string(ch, 40));
    }

    // 3. Character + count
    public static void DisplayLine(char ch, int count)
    {
        Console.WriteLine(new string(ch, count));
    }
}

class Program
{
    static void Main()
    {
        // Gym Membership Calculation
        decimal amount = GymMembership.CalculateMembershipAmount(
            treadMill: true,
            weightLifting: false,
            zumba: true
        );

        Console.WriteLine("Monthly Gym Membership Amount");
        LineDisplay.DisplayLine();
        Console.WriteLine("Total Amount (with GST): Rs. " + amount);
        LineDisplay.DisplayLine('$', 50);

        // Line display method overloading demo
        LineDisplay.DisplayLine();
        LineDisplay.DisplayLine('+');
        LineDisplay.DisplayLine('$', 60);
    }
}
