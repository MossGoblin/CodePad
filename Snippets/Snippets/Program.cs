using System;
using System.Collections.Generic;
using System.Linq;

namespace Snippets
{
    class Program
    {
        static void Main(string[] args)
        {
            //CheckBalance();
            //InitArray();
            //TestTheClass();
            TestArray();
        }

        private static void InitArray()
        {
            int collectionsCount = 5;
            int initValueInt = 3;
            double initValueDouble = 3.4;
            Console.WriteLine(String.Join(", ", Initializer.Init(collectionsCount, initValueInt)));
            Console.WriteLine(String.Join(", ", Initializer.Init(collectionsCount, initValueDouble)));
            Console.WriteLine(String.Join(", ", Initializer.InitIterative(collectionsCount, initValueInt)));
            Console.WriteLine(String.Join(", ", Initializer.InitIterative(collectionsCount, initValueDouble, initValueDouble)));
            Console.WriteLine(String.Join(", ", Initializer.InitIterative(collectionsCount, 22, 4, true)));
            Console.WriteLine(String.Join(", ", Initializer.InitIterative(collectionsCount, 182.4, 13.7, true)));
            double[] resultArray = Initializer.Init(collectionsCount, initValueDouble).ToArray();
            List<int> resultList = Initializer.Init(collectionsCount, initValueInt).ToList();
            Console.WriteLine($"Array: {String.Join(" . ", resultArray)}");
            Console.WriteLine($" List: {String.Join(" . ", resultList)}");
        }

        private static void CheckBalance()
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

        private static void TestArray()
        {
            double[] doubleArray1 = new Array<double>(5, 3.3).Return;
            Console.WriteLine("Double ctor : " + String.Join(", ", doubleArray1));
            double[] doubleArray2 = new Array<double>().Fill(5, 2.2);
            Console.WriteLine("Double mthd : " + String.Join(", ", doubleArray2));
            string[] stringArray = new Array<string>(6, "a").Return;
            Console.WriteLine("String ctor : " + String.Join(", ", stringArray));
        }

    }

}
