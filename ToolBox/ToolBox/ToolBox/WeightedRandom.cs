using System;
using System.Collections.Generic;
using System.Text;

namespace ToolBox
{
    public static class Weighted
    {
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
    }

}
