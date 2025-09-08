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
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nStudent {i + 1} Details:");

            // Name validation
            string name;
            while (true)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                Console.WriteLine("Name cannot be empty. Please try again.");
            }

            // Marks validation (0-100)
            int marks;
            while (true)
            {
                Console.Write("Enter marks (0-100): ");
                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                    break;
                Console.WriteLine("Invalid marks. Please enter an integer between 0 and 100.");
            }

            students.Add(new Student(name, marks));
        }

        // Sort using LINQ
        var sortedStudents = students
                             .OrderByDescending(s => s.Marks)
                             .ToList();

        Console.WriteLine("\nSorted Students by Marks (Highest First):");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }
    }
}
