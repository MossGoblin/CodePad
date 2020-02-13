﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryAttempt
{
    class Program
    {
        static void Main(string[] args)
        {
            // create pooler
            ObjectPooler pooler = new ObjectPooler();

            List<IPoolable> pooledList = new List<IPoolable>();

            int itemsToAdd = 7;
            int itemsToRemove = 3;
            int itemsToAddAgain = 5;

            // add some objects (ObjectOne)
            DoBusiness(pooler, itemsToAdd);
            // list what we have
            pooledList = ExtractPooled(pooler, typeof(ObjectOne), true);
            PrintList(pooledList);

            // remove some objects
            RemoveObjects(pooler, itemsToRemove, pooledList);
            pooledList = ExtractPooled(pooler, typeof(ObjectOne), true);
            PrintList(pooledList);

            // add some more objects (ObjectOne)
            DoBusiness(pooler, itemsToAddAgain); // TODO : HERE IT BREAKS
            // list what we have
            pooledList = ExtractPooled(pooler, typeof(ObjectOne), true);
            PrintList(pooledList);

        }

        private static void RemoveObjects(ObjectPooler pooler, int itemsToRemove, List<IPoolable> pooledList)
        {
            for (int count = 0; count < itemsToRemove; count++)
            {
                Factory<ObjectOne>.RemovePoolable(pooler, pooledList[count]);
            }
        }

        private static List<IPoolable> ExtractPooled(ObjectPooler pooler, Type type, bool activeOnly)
        {
            return Factory<ObjectOne>.ListPooledObjects(pooler, type, activeOnly);
        }

        private static void DoBusiness(ObjectPooler pooler, int iterations)
        {
            for (int count = 0; count < iterations; count++)
            {
                Factory<ObjectOne>.CreateObject(pooler);
            }
        }

        private static void PrintList(List<IPoolable> list)
        {
            Console.Write($"{list[0].GetType()}: ");
            foreach (var item in list)
            {
                ObjectOne obj = item as ObjectOne;
                Console.Write(obj.Index + ", ");
            }
            Console.WriteLine();
        }
    }
}