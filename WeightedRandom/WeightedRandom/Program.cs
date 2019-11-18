using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int iterations = 100;

            Console.WriteLine("\n- - -");
            Console.WriteLine(">> INT 0, 0, 100, 0 - should return always 3");
            for (int i = 0; i < iterations; i++)
            {
                sb.Append(Weighted.Random(new List<int> { 0, 0, 100, 0 }));
                sb.Append(", ");
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Console.WriteLine("\n- - -");
            Console.WriteLine(">> INT 100, 0, 100, 0 - should return 1 and 3 equally");
            for (int i = 0; i < iterations; i++)
            {
                sb.Append(Weighted.Random(new List<int> { 100, 0, 100, 0 }));
                sb.Append(", ");
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Console.WriteLine("\n- - -");
            Console.WriteLine(">> NORMAL 0, 0, 1, 0 - should return always 3");
            for (int i = 0; i < iterations; i++)
            {
                sb.Append(Weighted.RandomNormal(new List<double> { 0, 0, 1, 0 }));
                sb.Append(", ");
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();

            Console.WriteLine("\n- - -");
            Console.WriteLine(">> NORMAL 0.3, 0, 0.3, 0 - should return 1 and 3 equally");
            for (int i = 0; i < iterations; i++)
            {
                sb.Append(Weighted.RandomNormal(new List<double> { 0.3, 0, 0.3, 0 }));
                sb.Append(", ");
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
    }
}
