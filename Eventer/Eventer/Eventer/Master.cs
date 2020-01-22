using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    // creates and destroys subjects
    public class Master
    {
        // define delegate
        // define creation event
        // define removal event
        public delegate void OnSubjectChange(int index);

        public event OnSubjectChange OnSubjectCreated;
        public event OnSubjectChange OnSubjectRemoved;


        List<Subject> sbjList;
        Random rnd;
        public Master()
        {
            sbjList = new List<Subject>();
            rnd = new Random();

        }
        public void AddSubject()
        {
            Subject sbj = new Subject(rnd.Next(100));
            sbjList.Add(sbj);
            OnSubjectCreated(sbj.State);
        }

        public void RemoveSubject()
        {
            int index = rnd.Next(sbjList.Count);
            OnSubjectRemoved(sbjList[index].State);
            sbjList.RemoveAt(index);
        }
    }
}
