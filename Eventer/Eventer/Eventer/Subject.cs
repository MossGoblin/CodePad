using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    // main subject
    public class Subject
    {
        public int State { get; private set; }
        public Subject(int state)
        {
            this.State = state;
        }
    }
}
