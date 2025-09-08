class Program
{
    static void Main()
    {
        try
        {
            Validate();
            Process();
            Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            Console.WriteLine("StackTrace: " + ex.StackTrace);
        }
    }

    static void Validate()
    {
        Console.WriteLine("Validating...");
    }

    static void Process()
    {
        Console.WriteLine("Processing...");
        // Throw an exception intentionally to simulate failure
        throw new Exception("Error in Process");
    }

    static void Save()
    {
        Console.WriteLine("Saving...");
        // Not reached due to exception in Process
    }
}