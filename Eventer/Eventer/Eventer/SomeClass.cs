using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    class SomeClass
    {
        public delegate void ReportProgress(int progress);

        public void WorkOnThings(int iterations, ReportProgress report)
        {
            System.Random rnd = new System.Random();
            int progress = 0;

            for (int count = 0; count < iterations; count++)
            {
                progress += rnd.Next();
                report(progress);
            }
        }
    }
}
