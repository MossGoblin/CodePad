using System;
using System.Collections.Generic;

namespace temporee
{
    public class Program
    {
        static public void Main(string[] args)
        {

            int count = 0;
            int a = 7;
            int b = 9;
            int c = 3;
            int d = 5;

            Console.WriteLine("---");
            Console.WriteLine("Iterate");
            Console.WriteLine();
            foreach (var step in Griderator.Iterate(a, b))
            {
                Console.WriteLine($"(count {count} / calc {step.Item1 * b + step.Item2}) : {step.Item1} / {step.Item2}");
                count++;
            }

            Console.WriteLine("---");
            Console.WriteLine("Iterate range");
            Console.WriteLine();
            count = 0;
            foreach (var step in Griderator.IterateRange(c, a, d, b))
            {
                Console.WriteLine($"(count {count} / calc {step.Item1 * b + step.Item2}) : {step.Item1} / {step.Item2}");
                count++;
            }

            Console.WriteLine("---");
            Console.WriteLine("Iterate With Struct");
            Console.WriteLine();
            count = 0;
            foreach (var step in Griderator.IterateWithStruct(c, d))
            {
                Console.WriteLine($"(count {count} / calc {step.outer * b + step.inner}) : {step.outer} / {step.inner}");
                count++;
            }

            Console.WriteLine("---");
            Console.WriteLine("Iterate with Count");
            Console.WriteLine();
            count = 0;
            foreach (var step in Griderator.IterateWithCount(a, b))
            {
                Console.WriteLine($"(count {count} / calc {step.c}) : {step.i} / {step.y}");
                count++;
            }
        }

    }

    public class Griderator
    {
        public struct Step
        {
            public int outer;
            public int inner;

            public Step(int o, int i)
            {
                outer = o;
                inner = i;
            }
        }
        static public IEnumerable<Step> IterateWithStruct(int bound_i, int bound_b)
        {

            List<Step> loop = new List<Step>();
            for (int i = 0; i < bound_i; i++)
            {
                for (int y = 0; y < bound_b; y++)
                {
                    Step newStep = new Step(i, y);
                    loop.Add(newStep);
                }
            }

            return loop;
        }

        static public IEnumerable<(int i, int y)> Iterate(int bound_i, int bound_b)
        {
            List<(int i, int y)> loop = new List<(int i, int y)>();
            for (int i = 0; i < bound_i; i++)
            {
                for (int y = 0; y < bound_b; y++)
                {
                    loop.Add((i, y));
                }
            }

            return loop;
        }

        static public IEnumerable<(int i, int y, int c)> IterateWithCount(int bound_i, int bound_b)
        {
            List<(int i, int y, int c)> loop = new List<(int i, int y, int c)>();
            int count = 0;
            for (int i = 0; i < bound_i; i++)
            {
                for (int y = 0; y < bound_b; y++)
                {
                    loop.Add((i, y, count));
                    count++;
                }
            }

            return loop;
        }

        static public IEnumerable<(int i, int y)> IterateRange(int lower_i, int higher_i, int lower_y, int higher_b)
        {
            List<(int i, int y)> loop = new List<(int i, int y)>();
            for (int i = lower_i; i < higher_i; i++)
            {
                for (int y = lower_y; y < higher_b; y++)
                {
                    loop.Add((i, y));
                }
            }

            return loop;
        }
    }
}

