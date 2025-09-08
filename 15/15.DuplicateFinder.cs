using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter integers separated by spaces:");
        string input = Console.ReadLine();

        List<int> numbers = input
                            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

        var duplicates = numbers
                         .GroupBy(n => n)
                         .Where(g => g.Count() > 1)
                         .Select(g => g.Key)
                         .ToList();

        if (duplicates.Any())
        {
            Console.WriteLine("Duplicates: " + string.Join(", ", duplicates));
        }
        else
        {
            Console.WriteLine("No duplicates found.");
        }
    }
}