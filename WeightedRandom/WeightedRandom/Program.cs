using System;
using System.Collections.Generic;


namespace WeightedRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 10000000;
            int testNumber = 4;

            List<int> distIntEven = new List<int>() { 1, 1, 1, 1, 1, 1 };
            List<int> distIntCurve = new List<int>() { 1, 2, 3, 4, 3, 2 };

            List<double> distNRMEven = new List<double>() { 1, 1, 1, 1, 1, 1 };
            List<double> distNRMCurve = new List<double>() { 0.1, 0.2, 0.4, 0.5, 0.4, 0.2 };

            switch (testNumber)
            {
                case 1:
                    TestRandom("INT Even", distIntEven, iterations);
                    TestRandom("INT Curved", distIntCurve, iterations);
                break;
                case 2:
                    TestRandomNormal("Normal Even", distNRMEven, iterations);
                    TestRandomNormal("Normal Curved", distNRMCurve, iterations);
                break;
                case 3:
                    TestRandomReverse("Reverse Int Even", distIntEven, iterations);
                    TestRandomReverse("Reverse Int Curved", distIntCurve, iterations);
                break;
                case 4:
                    TestRandomNormalReverse("Reverse Normal Even", distNRMEven, iterations);
                    TestRandomNormalReverse("Reverse Normal Curved", distNRMCurve, iterations);
                break;
                default:
                    System.Console.WriteLine("No such test");
                break;
            }
        }

        private static void TestRandom(string display, List<int> dist, int iterations)
        {
            // Random test

            int[] collectorINT = new int[dist.Count];
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> {display} {String.Join(", ", dist)}");
            for (int i = 0; i < iterations; i++)
            {
                int result = Weighted.Random(dist);
                collectorINT[result] ++;
            }
            Console.WriteLine(String.Join(", ", collectorINT));
        }

        private static void TestRandomNormal(string display, List<double> dist, int iterations)
        {
            // RandomNormal test

            double[] collectorNRM = new double[dist.Count];
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> {display} {String.Join(", ", dist)}");
            for (int i = 0; i < iterations; i++)
            {
                int result = Weighted.RandomNormal(dist);
                collectorNRM[result] ++;
            }
            Console.WriteLine(String.Join(", ", collectorNRM));
        }

        private static void TestRandomReverse(string display, List<int> dist, int iterations)
        {
            // Random Reverse test

            int[] collectorINT = new int[dist.Count];
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> {display} {String.Join(", ", dist)}");
            for (int i = 0; i < iterations; i++)
            {
                int result = Weighted.Random(dist);
                collectorINT[result] ++;
            }

            // Eyeball test
            int lowest = int.MaxValue;
             foreach (var item in collectorINT)
            {
                lowest = Math.Min(lowest, item);
            }

            List<int> redacted = new List<int>();
            foreach (var item in collectorINT)
            {
                redacted.Add(item/lowest);
            }

            Console.WriteLine(String.Join(", ", collectorINT));
            Console.WriteLine(String.Join(", ", redacted));
        }

        private static void TestRandomNormalReverse(string display, List<double> dist, int iterations)
        {
            // RandomNormal test

            double[] collectorNRM = new double[dist.Count];
            Console.WriteLine("\n- - -");
            Console.WriteLine($">> {display} {String.Join(", ", dist)}");
            for (int i = 0; i < iterations; i++)
            {
                int result = Weighted.RandomNormal(dist);
                collectorNRM[result] ++;
            }

            // Eyeball test
            double lowest = double.MaxValue;
             foreach (var item in collectorNRM)
            {
                lowest = Math.Min(lowest, item);
            }

            List<double> redacted = new List<double>();
            foreach (var item in collectorNRM)
            {
                redacted.Add(item/lowest);
            }

            Console.WriteLine(String.Join(", ", collectorNRM));
            Console.WriteLine(String.Join(", ", redacted));
        }
    }
}
