using System.Diagnostics;
using System.Text;
class Program
{
    static void Main()
    {
        const int messageCount = 500;
        string message = "Rupak Molabanti CoStrategix Bengaluru";

        // Measure string concatenation time
        var sw = Stopwatch.StartNew();
        string log = "";
        for (int i = 1; i <= messageCount; i++)
        {
            log += message;
        }
        sw.Stop();
        Console.WriteLine($"String append time: {sw.ElapsedMilliseconds}ms");

        // Measure StringBuilder append time
        sw.Restart();
        var sb = new StringBuilder();
        for (int i = 1; i <= messageCount; i++)
        {
            sb.Append(message).Append(i).Append('\n');
        }
        sw.Stop();
        Console.WriteLine($"StringBuilder append time: {sw.ElapsedMilliseconds}ms");
    }
}