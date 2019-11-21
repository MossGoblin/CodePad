using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedRandom
{
    public static class Weighted
    {
        public static int Random(IEnumerable<int> weights)
        {
            int result = 0;

            // sum weights
            int sum = 0;
            foreach (var weight in weights)
            {
                sum += weight;
            }

            // roll a random
            Random rnd = new Random();
            int rndValue = rnd.Next(0, sum);

            // start accumulated comparison
            int accumulated = 0;
            int counter = 0;
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
            double sum = 0;
            foreach (var weight in weights)
            {
                sum += weight;
            }
            double factor = 1 / sum;

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
            int counter = 0;
            foreach (var weight in normWeights)
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

        public static int RandomReverse(IEnumerable<int> weights)
        {
            int result = 0;

            // sum weights
            int sum = 0;
            int maxValue = 0;
            foreach (var weight in weights)
            {
                sum += weight;
                maxValue = Math.Max(maxValue, weight);
            }

            // reverse weight table
            List<int> reversedWeights = new List<int>();
            foreach (var weight in weights)
            {
                reversedWeights.Add(maxValue - weight + 1);
            }


            // roll a random
            Random rnd = new Random();
            int rndValue = rnd.Next(0, sum);

            // start accumulated comparison
            int accumulated = 0;
            int counter = 0;
            foreach (var weight in reversedWeights)
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

        public static int RandomNormalReverse(IEnumerable<double> weights)
        {
            int result = 0;

            // sum weights
            double sum = 0;
            double maxValue = 0;
            foreach (var weight in weights)
            {
                sum += weight;
                maxValue = Math.Max(maxValue, weight);
            }
            double factor = 1 / sum;

            // reverse weight table
            List<double> reversedWeights = new List<double>();
            foreach (var weight in weights)
            {
                reversedWeights.Add(maxValue - weight + 1);
            }

            // normalize weights
            List<double> normWeights = new List<double>();
            foreach (var weight in reversedWeights)
            {
                normWeights.Add(weight * factor);
            }

            // roll a random
            Random rnd = new Random();
            double rndValue = rnd.NextDouble();

            // start accumulated comparison
            double accumulated = 0;
            int counter = 0;
            foreach (var weight in normWeights)
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
    }

}
