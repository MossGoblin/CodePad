using System;
using System.Collections.Generic;
using System.Text;

namespace States
{
    public static class StateMaster
    {
        public static States GetState(Context context, States currentState, Stances currentStance, int size, bool matured)
        {
            // check for STANCE change
            Stances newStance = UpdateStance(currentStance, size, matured);

            // check for STATE change
            int contextFPrint = context.fPrint;
            // TODO HERE - calculate selfFPrint based on size and stance; then compare to contextFPrint
        }

        private static Stances UpdateStance(Stances currentStance, int size, bool matured)
        {
            int stanceUpperBound = StanceData.StanceBounds[(int)currentStance, 0];
            int stanceLowerBound = StanceData.StanceBounds[(int)currentStance, 1];
            int newStanceIndex = 0;
            // are we NOT a berserk AND are we above the upper bound?
            if (currentStance != Stances.Berserk && size > stanceUpperBound)
            {
                // move one stance up
                newStanceIndex = (int)currentStance + 1;
            }

            // if we are NOT a coward AND are we matured AND are we below the lower bound?
            if (currentStance != Stances.Coward && matured && size <= stanceLowerBound)
            {
                // move one stance down
                newStanceIndex = (int)currentStance - 1;
            }
            return (Stances)newStanceIndex;
        }
    }
}
