using System;
using System.Collections.Generic;


namespace WeightedRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 1000000;
            int testNumber = 2;

            List<double> distEven = new List<double>() { 1, 1, 1, 1, 1, 1 };
            List<double> distCurve = new List<double>() { 1, 2, 4, 5, 4, 2 };

            switch (testNumber)
            {
                case 1:
                    TestRandom("Even", distEven, iterations);
                    TestRandom("Curved", distCurve, iterations);
                break;
                case 2:
                    TestRandomReverse("Reverse Even", distEven, iterations);
                    TestRandomReverse("Reverse Curved", distCurve, iterations);
                    break;
                default:
                    System.Console.WriteLine("No such test");
                break;
            }
        }

        private static void TestRandom(string display, List<double> dist, int iterations)
        {
            // Random test

            double[] collectorINT = new double[dist.Count];
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> {display} {String.Join(", ", dist)}");
            for (int i = 0; i < iterations; i++)
            {
                double result = Weighted.Random(dist);
                collectorINT[(int)result] ++;
            }
            Console.WriteLine(String.Join(", ", collectorINT));
        }

        private static void TestRandomReverse(string display, List<double> pop, int iterations)
        {
            // Random Reverse test

            int[] collectorINT = new int[pop.Count];
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> {display} {String.Join(", ", pop)}");
            for (int i = 0; i < iterations; i++)
            {
                int result = Weighted.RandomReverse(pop);
                collectorINT[result]++;
            }

            // Eyeball test
            int lowest = int.MaxValue;
            foreach (var item in collectorINT)
            {
                lowest = Math.Min(lowest, item);
            }

            List<double> redacted = new List<double>();
            int counter = 0;
            foreach (var item in collectorINT)
            {
                redacted.Add(item / lowest + pop[counter]);
                counter++;
            }

            Console.WriteLine(String.Join(", ", collectorINT));
            Console.WriteLine(String.Join(", ", redacted));
        }
    }
}
