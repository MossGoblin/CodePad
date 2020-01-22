using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eventer
{
    class Program
    {
        static void Main(string[] args)
        {
            Master master;
            ListenerSubjectCreation lstCreate;
            ListenerSubjectRemoval lstRemove;
            Random rnd = new Random();


            master = new Master();
            lstCreate = new ListenerSubjectCreation(master);
            lstRemove = new ListenerSubjectRemoval(master);

            for (int counter = 0; counter < 100; counter++)
            {
                master.AddSubject();
                if (rnd.Next(100)%3 == 0)
                {
                    master.RemoveSubject();
                }
            }

        }
    }

}
