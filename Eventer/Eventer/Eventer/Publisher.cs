using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    public delegate string StringExtract(Subject sbj, string str);
    public delegate Subject SubjectGenerator(int ID);

    class Publisher
    {
        public event StringExtract ExtractStrings;
        public event SubjectGenerator GenerateSubject;

        public Publisher()
        {
            this.GenerateSubject += new SubjectGenerator(GenNewSbj);
            this.ExtractStrings += new StringExtract(GetSbjString);
        }

        public string GetSbjString(Subject sbj, string str)
        {
            return ($"{str} + {sbj.ToString()}");
        }

        public Subject GenNewSbj(int ID)
        {
            Subject sbj = new Subject(ID);
            return sbj;
        }

    }
}
