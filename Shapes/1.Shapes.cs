using System.Collections.Generic;
public abstract class Shape
{
    public abstract double GetArea();
}

public interface IDrawable
{
    void Draw();
}

public class Circle : Shape, IDrawable
{
    private double radius;
    public Circle(double radius)
    {
        this.radius = radius;
    }
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
    public void Draw()
    {
        Console.Write("Drawing Circle");
    }
}

public class Rectangle : Shape, IDrawable
{
    private double width, height;
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }
    public override double GetArea()
    {
        return width * height;
    }
    public void Draw()
    {
        Console.Write("Drawing Rectangle");
    }
}

class Program
{
    static void Main()
    {
        var shapes = new List<Shape>();

        Console.Write("Enter shape count: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count < 1)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Shape {i + 1} type (circle/rectangle): ");
            string type = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(type))
            {
                Console.WriteLine("Invalid type, try again.");
                i--;
                continue;
            }

            type = type.Trim().ToLower();

            if (type == "circle")
            {
                double r;
                Console.Write("Enter radius: ");
                string input = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out r) || r <= 0)
                {
                    Console.Write("Please enter a positive number for radius: ");
                    input = Console.ReadLine();
                }
                shapes.Add(new Circle(r));
            }
            else if (type == "rectangle")
            {
                double w;
                Console.Write("Enter width: ");
                string inputW = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(inputW) || !double.TryParse(inputW, out w) || w <= 0)
                {
                    Console.Write("Please enter a positive number for width: ");
                    inputW = Console.ReadLine();
                }

                double h;
                Console.Write("Enter height: ");
                string inputH = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(inputH) || !double.TryParse(inputH, out h) || h <= 0)
                {
                    Console.Write("Please enter a positive number for height: ");
                    inputH = Console.ReadLine();
                }

                shapes.Add(new Rectangle(w, h));
            }
            else
            {
                Console.WriteLine("Invalid type, try again.");
                i--;
            }
        }

        foreach (Shape shape in shapes)
        {
            ((IDrawable)shape).Draw();
            Console.WriteLine($"Area: {shape.GetArea():0.00}");
        }
    }
}