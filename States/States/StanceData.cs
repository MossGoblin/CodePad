using System;
using System.Collections.Generic;
using System.Text;

namespace States
{
    public static class StanceData
    {
        public const int BerserkLowerBound = 5;

        public const int AggressiveUpperBound = 6;
        public const int AggressiveLowerBound = 4;

        public const int BalancedUpperBound = 5;
        public const int BalancesLowerBound = 3;

        public const int EvasiveUpperBound = 4;
        public const int EvasiveLowerBound = 2;

        public const int CowardUpperBound = 3;

        public static int[,] StanceBounds
        { 
            get
            {
                return StanceBounds;
            }

            private set
            {
                StanceBounds = new int[,]
                {
                { 0, BerserkLowerBound },
                { AggressiveUpperBound, AggressiveLowerBound},
                { BalancedUpperBound, BalancesLowerBound },
                { EvasiveUpperBound, EvasiveLowerBound },
                { CowardUpperBound, 0 }
                };
            }
        }
    }
}
