using System.Collections.Generic;
using System.Linq;
class Employee
{
    public string Name { get; set; }
    public string Dept { get; set; }
    public int Salary { get; set; }
}

class Program
{
    private const int high = 50000;
    static void Main()
    {
        var employees = new List<Employee>();

        Console.Write("Enter number of employees: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count < 1)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter details for Employee #{i + 1}:");

            Console.Write("Name: ");
            string name;
            while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
            {
                Console.Write("Name cannot be empty. Enter again: ");
            }

            Console.Write("Department: ");
            string dept;
            while (string.IsNullOrWhiteSpace(dept = Console.ReadLine()))
            {
                Console.Write("Department cannot be empty. Enter again: ");
            }

            Console.Write("Salary: ");
            int salary;
            while (!int.TryParse(Console.ReadLine(), out salary) || salary < 0)
            {
                Console.Write("Please enter a valid non-negative salary: ");
            }

            employees.Add(new Employee { Name = name.Trim(), Dept = dept.Trim(), Salary = salary });
        }

        Console.WriteLine();

        // 1. High Earners (Salary > 50000)
        var highEarners = employees
            .Where(e => e.Salary > high)
            .Select(e => e.Name);

        Console.WriteLine("High Earners: " + (highEarners.Any() ? string.Join(", ", highEarners) : "None"));

        // 2. Group by Department
        Console.WriteLine("Grouped:");
        var grouped = employees.GroupBy(e => e.Dept);
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Select(e => e.Name))}");
        }

        // 3. Max Salary
        var maxSalary = employees.OrderByDescending(e => e.Salary).First();
        Console.WriteLine($"Max Salary: {maxSalary.Name} -> {maxSalary.Salary}");
    }
}