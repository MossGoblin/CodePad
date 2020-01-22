using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    public class ListenerSubjectCreation
    {
        Master master;
        public ListenerSubjectCreation(Master master)
        {
            this.master = master;
            master.OnSubjectCreated += SubjectCreatedReport;
        }

        public void SubjectCreatedReport(int index)
        {
            Console.WriteLine($"New subject at: {index}");
        }
    }
}
