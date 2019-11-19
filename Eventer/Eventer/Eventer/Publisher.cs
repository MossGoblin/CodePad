using System;
using System.Collections.Generic;
using System.Text;

namespace Eventer
{
    public delegate string GenDel(Subject sbj, string str);

    class Publisher
    {
        public event GenDel GenEvent;

        public Publisher()
        {
            this.GenEvent += new GenDel(GetSbjString);
        }

        public string GetSbjString(Subject sbj, string str)
        {
            return ($"{str} + {sbj.ToString()}");
        }
    }
}
