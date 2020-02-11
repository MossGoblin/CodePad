using System;

namespace FactoryAttempt
{
    class Program
    {
        static void Main(string[] args)
        {
            // create pooler
            ObjectPooler pooler = new ObjectPooler();


            DoBusiness(pooler);
        }

        private static void DoBusiness(ObjectPooler pooler)
        {
            for (int count = 0; count < 5; count++)
            {
                Factory<ObjectOne>.CreateObject(pooler);
            }

            Factory<ObjectOne>.RemoveBulkObjects(pooler, 3);
        }


    }
}
