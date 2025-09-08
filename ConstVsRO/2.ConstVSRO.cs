public class AppInfo
{
    // const: must be assigned at declaration, value is fixed at compile time
    public const string AppName = "GBPPortal";

    // readonly: can be assigned at declaration or in constructor, fixed at runtime
    public readonly DateTime InitTime;

    public AppInfo()
    {
        InitTime = DateTime.Now; // Allowed: setting readonly in constructor
    }

    public void Display()
    {
        Console.WriteLine($"App Name: {AppName}");
        Console.WriteLine($"Initialized At: {InitTime}");
    }
}

class Program
{
    static void Main()
    {
        AppInfo app = new AppInfo();
        app.Display();
    }
}