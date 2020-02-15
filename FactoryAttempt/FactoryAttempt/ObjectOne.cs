using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAttempt
{
    class ObjectOne : IProduct
    {
        public int Index { get; private set; }

        public ObjectOne()
        {
            Random rnd = new Random();
            this.Index = rnd.Next(10000);
        }
        public string GetName()
        {
            return $"[{this.GetName().ToString()} {Index}]";
        }
    }
}
