using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAttempt
{
    class ObjectTwo : IPoolable
    {
        private int index;

        public ObjectTwo()
        {
            Random rnd = new Random();
            this.index = rnd.Next(10000);
        }
        public string GetName()
        {
            return $"[{this.GetName().ToString()} {index}]";
        }
    }
}
