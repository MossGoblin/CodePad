using System;
using System.Collections.Generic;
using System.Text;

namespace Snippets
{
    static class BalanceChecker
    {
        public static List<int> stateCollection;

        static BalanceChecker()
        {
            stateCollection = new List<int>();
        }

        public static double GetMeanDiff()
        {
            int span = stateCollection.Count;
            List<double> diffs = new List<double>();
            double meanState = 0;
            double stateSum = 0;
            foreach (var state in stateCollection)
            {
                stateSum += (double)state;
            }
            meanState = stateSum / span;
            double totalDiff = 0;
            foreach (var state in stateCollection)
            {
                totalDiff += Math.Abs((double)(state) - meanState);
            }
            double meanDiff = totalDiff / span;

            return meanDiff;
        }

        public static double GetBalance()
        {
            double meanDiff = GetMeanDiff();
            double maxStat = 0;
            foreach (var stat in stateCollection)
            {
                maxStat = Math.Max(maxStat, stat);
            }
            double balance = 1 - (meanDiff / maxStat);
            return balance;
        }
    }
}
