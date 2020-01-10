using System;
using System.Collections.Generic;
using ToolBox;

namespace Accessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRandom();
			TestBalance();
		}

        public static void TestRandom()
        {
			int counter = 10;
			List<int> weights = new List<int>();
			for (int count = 0; count < counter; count++)
			{
				weights.Add(count % 3);
			}
			Console.WriteLine(String.Join(", ", weights));

			int[] result = new int[counter];
			for (int count = 0; count < counter; count++)
			{
				result[count] = 0;
			}

			for (int count = 0; count < counter * 100; count++)
			{
				result[Weighted.Random(weights)]++;
			}
			Console.WriteLine(String.Join(", ", result));
		}

		public static void TestBalance()
		{
			int listCount = 10;
			int listSize = 10;
			List<List<int>> collectionsList = new List<List<int>>();
			List<int> controlCollectionOne = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
			List<int> controlCollectionTwo = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 0, 0 };
			List<int> controlCollectionThree = new List<int> { 10, 10, 10, 10, 10, 5, 5, 5, 5, 5 };

			collectionsList.Add(controlCollectionOne);
			collectionsList.Add(controlCollectionTwo);
			collectionsList.Add(controlCollectionThree);

			Random rnd = new Random();

			for (int countC = 0; countC < listCount-3; countC++)
			{
				List<int> newCollection = new List<int>();
				for (int countS = 0; countS < listSize; countS++)
				{
					newCollection.Add(rnd.Next(0, 11));
				}
				Console.WriteLine();
				collectionsList.Add(newCollection);
			}

			foreach (List<int> collection in collectionsList)
			{
				Console.WriteLine($"{String.Join(", ", collection)} : balance {Weighted.Balance(collection, false)}");
				Console.WriteLine($"{String.Join(", ", collection)} : balance {Weighted.Balance(collection, true)}");
				Console.WriteLine("- - -");
			}
		}
	}
}
