using System;

namespace DAY16
{
    // Utility class using only static members
    public static class ApplicationConfig
    {
        // 1️⃣ Static Properties
        public static string ApplicationName { get; private set; }
        public static string Environment { get; private set; }
        public static int AccessCount { get; private set; }
        public static bool IsInitialized { get; private set; }

        // 2️⃣ Static Constructor
        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;

            Console.WriteLine("Static constructor executed");
        }

        // 3️⃣ Static Methods

        // a) Initialize
        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        // b) GetConfigurationSummary
        public static string GetConfigurationSummary()
        {
            AccessCount++;

            return $"Application Name: {ApplicationName}\n" +
                   $"Environment: {Environment}\n" +
                   $"Access Count: {AccessCount}\n" +
                   $"Is Initialized: {IsInitialized}";
        }

        // c) ResetConfiguration
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;
        }
    }

    // Program class
    internal class Program
    {
        static void Main(string[] args)
        {
            // 🔹 Access static property (triggers static constructor)
            Console.WriteLine("App Name (initial): " + ApplicationConfig.ApplicationName);
            Console.WriteLine();

            // 🔹 Initialize configuration
            ApplicationConfig.Initialize("EmployeePortal", "Production");

            // 🔹 Get configuration summary
            string summary = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("Configuration Summary:");
            Console.WriteLine(summary);
            Console.WriteLine();

            // 🔹 Reset configuration
            ApplicationConfig.ResetConfiguration();

            // 🔹 Get summary again after reset
            Console.WriteLine("After Reset:");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());

            Console.ReadLine();
        }
    }
}
