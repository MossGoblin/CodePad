using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAttempt
{
    public class PoolManager
    {
        public Dictionary<Type, Dictionary<IProduct, bool>> pools;

        public PoolManager()
        {
            pools = new Dictionary<Type, Dictionary<IProduct, bool>>();
        }
    }
}
