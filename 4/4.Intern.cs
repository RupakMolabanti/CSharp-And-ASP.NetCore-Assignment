class Program
{
    static void Main()
    {
        string a = "Rupak";  // first string
        // Create second string via new string(char[]) to simulate runtime creation
        string b = new string(a.ToCharArray());

        // Compare references before interning
        bool beforeIntern = object.ReferenceEquals(a, b);
        Console.WriteLine("Reference equals before intern: " + beforeIntern);

        // Intern string b explicitly
        string bInterned = string.Intern(b);

        // Compare references after interning
        bool afterIntern = object.ReferenceEquals(a, bInterned);
        Console.WriteLine("Reference equals After Intern: " + afterIntern);
    }
}