using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string s = input.ToLower().Replace(" ", "");

        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (freq.ContainsKey(c))
            {
                freq[c]++;
            }
            else
            {
                freq[c] = 1;
            }
        }

        var sorted = freq.OrderBy(pair => pair.Key);

        Console.WriteLine("\nCharacter Frequency:");
        foreach (var i in sorted)
        {
            Console.WriteLine($"{i.Key} -> {i.Value}");
        }
    }
}
