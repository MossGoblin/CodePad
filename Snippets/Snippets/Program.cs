using System;

namespace Snippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter states:");
            string input = Console.ReadLine();
            bool goodInput;
            int inputStateNumber;
            goodInput = Int32.TryParse(input, out inputStateNumber);
            while (goodInput)
            {
                BalanceChecker.stateCollection.Add(inputStateNumber);
                input = Console.ReadLine();
                goodInput = Int32.TryParse(input, out inputStateNumber);
            }
            Console.WriteLine(String.Join(", ", BalanceChecker.stateCollection));
            Console.WriteLine($"Disbalance = {BalanceChecker.GetMeanDiff()}");
            Console.WriteLine($"Disbalance = {BalanceChecker.GetBalance()}");
        }
    }
}
