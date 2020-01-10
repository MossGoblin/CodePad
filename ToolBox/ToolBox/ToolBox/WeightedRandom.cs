using System;
using System.Collections.Generic;
using System.Text;

namespace ToolBox
{
    public static class Weighted
    {
        /// <summary>
        /// A method that selects a random index in an IEnumerable, with higher values in the IEnumerable having higher probability of their index being selected
        /// </summary>
        /// <param name="weights">A Collection (IEnumerable) of weights</param>
        /// <returns></returns>
        public static int Random(IEnumerable<int> weights)
        {
            int result = 0;

            // sum weights
            int maxValue = 0;
            foreach (var weight in weights)
            {
                maxValue += weight;
            }

            // roll a random
            Random rnd = new Random();
            int rndValue = rnd.Next(0, maxValue);

            // start accumulated comparison
            int accumulated = 0;
            int counter = 1;
            foreach (var weight in weights)
            {
                accumulated += weight;
                if (accumulated >= rndValue)
                {
                    result = counter;
                    break;
                }
                counter++;
            }
            return result;
        }

        public static int RandomNormal(IEnumerable<double> weights)
        {
            int result = 0;

            // sum weights
            double maxValue = 0;
            foreach (var weight in weights)
            {
                maxValue += weight;
            }
            double factor = 1 / maxValue;

            // normalize weights
            List<double> normWeights = new List<double>();
            foreach (var weight in weights)
            {
                normWeights.Add(weight * factor);
            }

            // roll a random
            Random rnd = new Random();
            double rndValue = rnd.NextDouble();

            // start accumulated comparison
            double accumulated = 0;
            int counter = 1;
            foreach (var weight in weights)
            {
                accumulated += weight;
                if (accumulated >= rndValue)
                {
                    result = counter;
                    break;
                }
                counter++;
            }
            return result;
        }

        public static double Balance(IEnumerable<int> collection, bool zeroesAllowed)
        {
            // validate non-negative or positive members
            // calculate sum, count, max, min, span and average
            int sum = 0;
            int count = 0;
            int max = 0;
            double average = 0f;
            foreach (int member in collection)
            {
                sum += member;
                if ((zeroesAllowed && member == 0) || member != 0)
                {
                    count++;
                }
                max = Math.Max(max, member);
            }
            average = sum / count;

            // calculate deviations
            double totalDeviation = 0;
            foreach (int member in collection)
            {
                if ((zeroesAllowed && member == 0) || member != 0)
                {
                    double deviation = Math.Abs(member - average);
                    totalDeviation += deviation;
                }
            }
            double averageDeviation = totalDeviation / count;
            double percentileDeviation = averageDeviation / max;
            double balance = 1 - percentileDeviation;

            return balance;
        }

        public static double Balance(IEnumerable<double> collection, bool zeroesAllowed)
        {
            // validate non-negative or positive members
            // calculate sum, count, max, min, span and average
            double sum = 0;
            double count = 0;
            double max = 0;
            double average = 0f;
            foreach (double member in collection)
            {
                sum += member;
                if ((zeroesAllowed && member == 0) || member != 0)
                {
                    count++;
                }
                max = Math.Max(max, member);
            }
            average = sum / count;

            // calculate deviations
            double totalDeviation = 0;
            foreach (double member in collection)
            {
                if ((zeroesAllowed && member == 0) || member != 0)
                {
                    double deviation = Math.Abs(member - average);
                    totalDeviation += deviation;
                }
            }
            double averageDeviation = totalDeviation / count;
            double percentileDeviation = averageDeviation / max;
            double balance = 1 - percentileDeviation;

            return balance;
        }
    }

}
