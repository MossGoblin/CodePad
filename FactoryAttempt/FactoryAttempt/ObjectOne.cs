using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAttempt
{
    class ObjectOne : IPoolable
    {
        private int index;

        public ObjectOne()
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
