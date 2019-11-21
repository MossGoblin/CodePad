using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WeightedRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int iterations = 100;


            // Console.WriteLine("\n- - -");
            // Console.WriteLine(">> INT 0, 0, 100, 0 - should return always 3");
            // for (int i = 0; i < iterations; i++)
            // {
            //     sb.Append(Weighted.Random(new List<int> { 0, 0, 100, 0 }));
            //     sb.Append(", ");
            // }
            // Console.WriteLine(sb.ToString());
            // sb.Clear();

            // Console.WriteLine("\n- - -");
            // Console.WriteLine(">> INT 100, 0, 100, 0 - should return 1 and 3 equally");
            // for (int i = 0; i < iterations; i++)
            // {
            //     sb.Append(Weighted.Random(new List<int> { 100, 0, 100, 0 }));
            //     sb.Append(", ");
            // }
            // Console.WriteLine(sb.ToString());
            // sb.Clear();

            // Console.WriteLine("\n- - -");
            // Console.WriteLine(">> NORMAL 0, 0, 1, 0 - should return always 2");
            // for (int i = 0; i < iterations; i++)
            // {
            //     sb.Append(Weighted.RandomNormal(new List<double> { 0, 0, 1, 0 }));
            //     sb.Append(", ");
            // }
            // Console.WriteLine(sb.ToString());
            // sb.Clear();

            // Console.WriteLine("\n- - -");
            // Console.WriteLine(">> NORMAL 0.3, 0, 0.3, 0 - should return 0 and 2 fairly equally");
            // for (int i = 0; i < iterations; i++)
            // {
            //     sb.Append(Weighted.RandomNormal(new List<double> { 0.3, 0, 0.3, 0 }));
            //     sb.Append(", ");
            // }
            // Console.WriteLine(sb.ToString());
            // sb.Clear();


            List<int> population = new List<int>() { 1, 20, 50, 5, 1, 20, 50, 5 };

            // custom iteration value for large test
            // iterations = 100000000;
            // Console.WriteLine("\n- - -");
            // Console.WriteLine(">> REV INT 1, 20, 50, 5, 1, 20, 50, 5 - should return preferrably the smallest indices");
            // for (int i = 0; i < iterations; i++)
            // {
            //     int incoming = Weighted.RandomReverse(population);
            //     // sb.Append(incoming);
            //     // sb.Append(", ");
            //     population[incoming] += 1;
            //     // Console.WriteLine(incoming + " : " + String.Join(", ", population));

            // }
            // //Console.WriteLine(sb.ToString());
            // Console.WriteLine(String.Join(", ", population));
            // sb.Clear();

            // // second reverse test with leveled distribution
            List<int> leveledPopulation = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };
            iterations = 100;
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> REV INT {String.Join(", ", leveledPopulation)} - should return preferrably the smallest indices");
            for (int i = 0; i < iterations; i++)
            {
                int incoming = Weighted.RandomReverse(leveledPopulation);
                sb.Append(incoming);
                sb.Append(", ");
                leveledPopulation[incoming] += 1;
                Console.WriteLine(incoming + " : " + String.Join(", ", leveledPopulation));
            }
            //Console.WriteLine(sb.ToString());
            System.Console.WriteLine();
            Console.WriteLine(String.Join(", ", leveledPopulation));
            System.Console.WriteLine("mean: " + GetMean(leveledPopulation).mean + " / amplitude: " + (GetMean(leveledPopulation).max - GetMean(leveledPopulation).min));
            sb.Clear();
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
