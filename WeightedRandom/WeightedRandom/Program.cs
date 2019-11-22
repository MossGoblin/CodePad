using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WeightedRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 1000000;

            List<int> distInt = new List<int>() { 1, 1, 1, 1, 1, 1 };
            int[] collectorINT = new int[distInt.Count];

            Console.WriteLine("\n- - -");
            Console.WriteLine($">> INT {String.Join(", ", distInt)}");
            for (int i = 0; i < iterations; i++)
            {
                int result = Weighted.Random(distInt);
                collectorINT[result] ++;
            }
            Console.WriteLine(String.Join(", ", collectorINT));
        }

        private static (int mean, int max, int min) GetMean(List<int> distribution)
        {
            int sum = 0;
            int max = 0;
            int min = distribution[0];
            foreach (var item in distribution)
            {
                max = Math.Max(max, item);
                min = Math.Min(min, item);
                sum += item;
            }
            return (sum/(distribution.Count+1), max, min);
        }
    }
}
