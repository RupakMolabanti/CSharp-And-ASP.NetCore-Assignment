using System.Collections.Generic;
using System.Linq;
class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }

    public Student(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>();

        int count;
        while (true)
        {
            Console.Write("Enter number of students: ");
            if (int.TryParse(Console.ReadLine(), out count) && count > 0)
                break;
            Console.WriteLine("Please enter a valid positive number.");
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter details for Student {i + 1}:");

            string name;
            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                Console.WriteLine("Name cannot be empty.");
            }

            int marks;
            while (true)
            {
                Console.Write("Marks (0-100): ");
                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                    break;
                Console.WriteLine("Please enter marks between 0 and 100.");
            }

            students.Add(new Student(name, marks));
        }

        int topMark = students.Max(s => s.Marks);
        var topScorers = students.Where(s => s.Marks == topMark).ToList();
        double average = students.Average(s => s.Marks);
        var aboveAverage = students
                            .Where(s => s.Marks > average)
                            .Select(s => s.Name)
                            .ToList();

        Console.WriteLine("\nStudent Marks Report");
        Console.WriteLine("Top Scorers:");
        foreach (var s in topScorers)
            Console.WriteLine($"{s.Name} - {s.Marks}");

        Console.WriteLine($"Average Marks: {average:F2}");

        Console.WriteLine("Above Average:");
        if (aboveAverage.Any())
            Console.WriteLine(string.Join(", ", aboveAverage));
        else
            Console.WriteLine("None");
    }
}