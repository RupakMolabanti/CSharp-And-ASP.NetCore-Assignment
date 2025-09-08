using System.Threading;
class BankAccount
{
    private int balance = 1000;
    private readonly object balanceLock = new object();

    public void Withdraw(int amount, int threadId)
    {
        lock (balanceLock)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Thread {threadId}: Withdraw Success");
            }
            else
            {
                Console.WriteLine($"Thread {threadId}: Withdraw Failed - Insufficient Funds");
            }
        }
    }

    public int GetBalance() => balance;
}

class Program
{
    static void Main()
    {
        var account = new BankAccount();

        Console.Write("Enter withdrawal amount: ");
        int withdrawAmount = int.Parse(Console.ReadLine());

        Console.Write("Enter number of threads: ");
        int threadCount = int.Parse(Console.ReadLine());

        Thread[] threads = new Thread[threadCount];

        // Create and start threads
        for (int i = 0; i < threadCount; i++)
        {
            int threadId = i + 1;
            threads[i] = new Thread(() => account.Withdraw(withdrawAmount, threadId));
            threads[i].Start();
        }

        // Wait for all threads to complete
        foreach (var t in threads)
        {
            t.Join();
        }

        Console.WriteLine($"Final Balance: {account.GetBalance()}");
    }
}