using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    public class ListenerSubjectRemoval
    {
        Master master;
        public ListenerSubjectRemoval(Master master)
        {
            this.master = master;
            master.OnSubjectRemoved += SubjectRemovedReport;
        }
        public void SubjectRemovedReport(int index)
        {
            Console.WriteLine($"Subject removed at: {index}");
        }
    }
}
