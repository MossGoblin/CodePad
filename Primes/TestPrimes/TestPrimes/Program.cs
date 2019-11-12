using System;
using System.Collections.Generic;
using System.Linq;
using MathPrimes;


namespace TestPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            MathP primath = new MathP();

            //Console.WriteLine("- - - - - - -");
            //Console.WriteLine("1. Test if a number is prime");
            //Console.Write("Number to test: ");
            //ulong testNumber = ulong.Parse(Console.ReadLine());
            //Console.WriteLine($"{testNumber} result: {primath.IsPrime(testNumber)}");
            //Console.WriteLine($"collected {primath.GetCached().Count} :: {PrintCollected(primath.GetCached())}");


            //Console.WriteLine("- - - - - - -");
            //Console.WriteLine("2. Number of primes up to a number");
            //Console.Write("Upper bound (inclusive): ");
            //ulong upper = ulong.Parse(Console.ReadLine());
            //Console.WriteLine($"up to {upper} result: {PrintList(primath.PrimesBelow(upper))}");
            //Console.WriteLine($"collected {primath.GetCached().Count} :: {PrintCollected(primath.GetCached())}");

            //Console.WriteLine("- - - - - - -");
            //Console.WriteLine("3. Number of primes in a range");
            //Console.Write("Lower bound: ");
            //ulong lower = ulong.Parse(Console.ReadLine());
            //Console.Write("Upper bound: ");
            //upper = ulong.Parse(Console.ReadLine());
            //Console.WriteLine($"{lower}..{upper} result: {PrintList(primath.PrimesInRange(lower, upper))}");
            //Console.WriteLine($"collected {primath.GetCached().Count} :: {PrintCollected(primath.GetCached())}");

            Console.WriteLine("- - - - - - -");
            Console.WriteLine("4. Factors of a number");
            Console.Write("Number: ");
            ulong target = ulong.Parse(Console.ReadLine());
            Console.WriteLine($"{target} result: {PrintList(primath.Factors(target))}");

            Console.WriteLine("- - - - - - -");
            Console.WriteLine("5. Prime factors of a number");
            Console.Write("Number: ");
            target = ulong.Parse(Console.ReadLine());
            Console.WriteLine($"{target} result: {PrintList(primath.PrimeFactors(target))}");

        }

        public static string PrintList(List<ulong> list)
        {
            return String.Join(", ", list);
        }

        public static string PrintCollected(SortedDictionary<ulong, bool> dict)
        {
            List<ulong> list = new List<ulong>();
            foreach (var item in dict)
            {
                if (item.Value)
                {
                    list.Add(item.Key);
                }
            }

            return String.Join(", ", list.OrderBy(n => n));
        }
    }
}