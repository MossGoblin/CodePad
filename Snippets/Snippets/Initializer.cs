using System;
using System.Collections.Generic;
using System.Text;

namespace Snippets
{
    static class Initializer
    {
        public static IEnumerable<int> Init(int size, int value)
        {
            List<int> initializedCollection = new List<int>();
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(value);
            }

            return initializedCollection;
        }

        public static IEnumerable<double> Init(int size, double value)
        {
            List<double> initializedCollection = new List<double>();
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(value);
            }

            return initializedCollection;
        }

        public static IEnumerable<int> InitIterative(int size, int startValue, int step)
        {
            List<int> initializedCollection = new List<int>();
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(startValue + step * counter);
            }

            return initializedCollection;
        }

        public static IEnumerable<int> InitIterative(int size, int startValue, int step, bool descending)
        {
            List<int> initializedCollection = new List<int>();
            int descendingFactor = descending ? -1 : 1;
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(startValue + step * counter * descendingFactor);
            }

            return initializedCollection;
        }

        public static IEnumerable<int> InitIterative(int size, int startValue)
        {
            List<int> initializedCollection = new List<int>();
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(startValue + counter);
            }

            return initializedCollection;
        }

        public static IEnumerable<int> InitIterative(int size, int startValue, bool descending)
        {
            List<int> initializedCollection = new List<int>();
            int descendingFactor = descending ? -1 : 1;
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(startValue + counter * descendingFactor);
            }

            return initializedCollection;
        }

        public static IEnumerable<double> InitIterative(int size, double startValue, double step)
        {
            List<double> initializedCollection = new List<double>();
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(startValue + step * counter);
            }

            return initializedCollection;
        }

        public static IEnumerable<double> InitIterative(int size, double startValue, double step, bool descending)
        {
            List<double> initializedCollection = new List<double>();
            int descendingFactor = descending ? -1 : 1;
            for (int counter = 0; counter < size; counter++)
            {
                initializedCollection.Add(startValue + step * counter * descendingFactor);
            }

            return initializedCollection;
        }
    }
}
