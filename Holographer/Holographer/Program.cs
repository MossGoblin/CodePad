using System;

namespace Holographer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Init!");
            float[] original = new float[] { 1, 2, 5, 7, 3, 8, 1, 1, 3 };
            float[] partials = new float[original.Length];
            float[] proximity = new float[original.Length];

            // original
            Console.WriteLine("\n- - -");
            Console.WriteLine("original:");
            Console.WriteLine(String.Join(" ", original));

            // partials
            for (int count = 0; count < original.Length; count++)
            {
                partials[count] = GetTotal(original) / original[count];
            }
            Console.WriteLine("\n- - -");
            Console.WriteLine("partials (ratio of total):");
            Console.WriteLine(String.Join(" ", partials));

            // proximity
            for (int count = 0; count < original.Length; count++)
            {
                var nbrs = GetNbrs(original, count);
                proximity[count] = (nbrs.prev + nbrs.next) / 2;
            }
            Console.WriteLine("\n- - -");
            Console.WriteLine("proximity (average weight of nbrs):");
            Console.WriteLine(String.Join(" ", proximity));
        }

        public static (float prev, float next) GetNbrs(float[] original, int pos)
        {
            float prevNbr = original[pos];
            float nextNbr = original[pos];
            if (pos >= 1)
            {
                prevNbr = original[pos - 1];
            }
            else
            {
                prevNbr = original[pos + 1] - original[pos];
            }

            if (pos < original.Length - 1)
            {
                nextNbr = original[pos + 1];
            }
            else
            {
                prevNbr = original[pos] - original[pos - 1];
            }

            return (prevNbr, nextNbr);
        }

        static float GetMean(float[] array)
        {
            float mean = 0;
            foreach (int pos in array)
            {
                mean += pos;
            }
            return mean / array.Length;
        }

        static float GetTotal(float[] array)
        {
            float total = 0;
            foreach (float pos in array)
            {
                total += pos;
            }
            return total;
        }

    }
}
