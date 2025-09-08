using System.Collections.Generic;
class Question
{
    public string Text { get; }
    public List<string> Options { get; }
    public char CorrectAnswer { get; }

    public Question(string text, List<string> options, char correctAnswer)
    {
        Text = text;
        Options = options;
        CorrectAnswer = char.ToLower(correctAnswer);
    }

    public void Display(int qNum)
    {
        Console.WriteLine($"Q{qNum}: {Text}");
        char opt = 'a';
        foreach (var option in Options)
        {
            Console.WriteLine($"{opt}. {option}");
            opt++;
        }
    }

    public bool CheckAnswer(char answer)
    {
        return char.ToLower(answer) == CorrectAnswer;
    }
}

class Program
{
    static void Main()
    {
        var questions = new List<Question>
        {
            new Question("What is C#?", new List<string>{"Language", "Fruit", "Car", "None"}, 'a'),
            new Question("Which is a value type?", new List<string>{"string", "int", "object", "class"}, 'b'),
            new Question("What does OOP stand for?", new List<string>{"Object Oriented Programming", "Ordinary Optional Programming", "Order Of Processing", "None"}, 'a'),
            new Question("Which keyword is used for inheritance?", new List<string>{"base", "sealed", "extends", ":",}, 'd'),
            new Question("What collection type allows duplicates?", new List<string>{"Set", "Dictionary", "List", "HashSet"}, 'c'),
        };

        int score = 0, qNum = 1;
        foreach (var question in questions)
        {
            question.Display(qNum);
            Console.Write("Your Answer: ");
            char answer = char.ToLower(Console.ReadLine()[0]);
            if (question.CheckAnswer(answer))
                score++;
            qNum++;
            Console.WriteLine();
        }

        Console.WriteLine($"Final Score: {score}/{questions.Count}");
    }
}
