using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedRandom
{
    public static class Weighted
    {
        public static int Random(IEnumerable<double> distribution)
        {
            // check validity
            bool negatives = false;
            foreach (var member in distribution)
            {
                if (member < 0)
                {
                    negatives = true;
                    break;
                }
            }

            if (negatives)
            {
                throw new ArgumentException("The input distribution must contain only non-negative values");
            }

            // roll a random
            Random rnd = new Random();
            double normalRandom = rnd.NextDouble();

            // get the sum of the distribution
            double sum = 0;
            foreach (var member in distribution)
            {
                sum += member;
            }

            // resize the target
            double target = normalRandom * sum;

            // iterate distribution
            double partial = 0;
            int counter = 0;
            int result = 0;
            foreach (var member in distribution)
            {
                partial += member;
                if (target <= partial)
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

        public static int RandomReverse(IEnumerable<double> population)
        {
            // check validity
            bool negatives = false;
            foreach (var member in population)
            {
                if (member < 0)
                {
                    negatives = true;
                    break;
                }
            }

            if (negatives)
            {
                throw new ArgumentException("The input population must contain only non-negative values");
            }

            // roll a random
            Random rnd = new Random();
            double normalRandom = rnd.NextDouble();

            // get the sum of the distribution
            double sum = 0;
            double max = 0;
            foreach (var member in population)
            {
                sum += member;
                max = Math.Max(max, member);
            }

            // build reverse population
            List<double> populationRev = new List<double>();
            foreach (var member in population)
            {
                populationRev.Add(max - member + 1);
            }

            // resize the target
            double target = normalRandom * sum;

            // iterate distribution
            double partial = 0;
            int counter = 0;
            int result = 0;
            foreach (var member in populationRev)
            {
                partial += member;
                if (target <= partial)
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
    }
}
