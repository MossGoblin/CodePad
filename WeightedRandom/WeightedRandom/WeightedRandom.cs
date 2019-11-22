using System;
using System.Collections.Generic;

namespace WeightedRandom
{
    public static class Weighted
    {
        public static int Random(IEnumerable<int> weights)
        {
            // check for validity - fine
            bool positive = false;
            bool negatives = false;
            foreach (var weight in weights)
        	{
                if (weight > 0)
            	{
                    positive = true;

            	}
                if (weight < 0)
            	{
                    negatives = true;
            	}
        	}

            if (!positive || negatives)
        	{
                throw new ArgumentException("The distribution should have no negativ evalues and at least one positive value");
        	}

            int result = 0;

            // sum weights - fine
            int sum = 0;
            foreach (var weight in weights)
            {
                sum += weight;
            }

            // roll a random
            Random rnd = new Random();
            int rndValue = rnd.Next(0, sum + 1);

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
                else
                {
                    counter++;
                }
            }
            return result;
        }

        public static int RandomNormal(IEnumerable<double> weights)
        {
            // check validity - OK
            foreach (var weight in weights)
            {
                if (weight > 1 || weight < 0)
                {
                    throw new ArgumentException("The distribution must contain values between 0 and 1");
                }
            }

            int result = 0;

            // sum weights
            double sum = 0;
            foreach (var weight in weights)
            {
                sum += weight;
            }

            // normalize weights
            double factor = 1 / sum;
            List<double> normWeights = new List<double>();
            foreach (var weight in weights)
            {
                normWeights.Add(weight * factor);
            }

            // roll a random - OK
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
                else
                {
                    counter++;
                }
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

        private static Dictionary<int, int> SortDistribution(IEnumerable<int> weights)
        {
            Dictionary<int, int> sortedMap = new Dictionary<int, int>();

            // sort weights into the dictionary and mark the corresponding indices
            // TODO HERE
            return sortedMap;
        }

    }
}
