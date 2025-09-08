using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.Write("Enter a string to reverse: ");
        string input = Console.ReadLine();

        // Create a stack to hold characters
        Stack<char> stack = new Stack<char>();

        // Push each character into the stack
        foreach (char c in input)
        {
            stack.Push(c);
        }

        // Pop from the stack to get reversed string
        string reversed = "";
        while (stack.Count > 0)
        {
            reversed += stack.Pop();
        }

        Console.WriteLine("Reversed string: " + reversed);
    }
}