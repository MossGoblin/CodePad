using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAttempt
{
    public class ObjectPooler
    {
        public Dictionary<Type, Dictionary<IPoolable, bool>> pools;

        public ObjectPooler()
        {
            pools = new Dictionary<Type, Dictionary<IPoolable, bool>>();
        }
    }
}
