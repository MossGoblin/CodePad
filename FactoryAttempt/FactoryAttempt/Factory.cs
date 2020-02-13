using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryAttempt
{
    public static class Factory<T> where T : IPoolable
    {
        public static IPoolable CreateObject(ObjectPooler pooler)
        {
            Type objectType = typeof(T);
            // check if the pooler has the appopriate pool
            if (pooler.pools.ContainsKey(objectType)) // the pooler has the type pool
            {
                // check if there is an available object
                if (pooler.pools[objectType].ContainsValue(false)) // there is an available object
                {
                    // extract the object
                    IPoolable activatedObject = pooler.pools[objectType].FirstOrDefault(p => p.Value == false).Key;
                    // mark it as activated
                    pooler.pools[objectType][activatedObject] = false;
                    // return the activated object
                    return activatedObject;
                }
                else // there is no available object
                {
                    // create new object
                    IPoolable newObjectTypeAsIPoolable = (IPoolable)Activator.CreateInstance(objectType);
                    // pool the object
                    pooler.pools[objectType].Add(newObjectTypeAsIPoolable, true);
                    // return the object
                    return newObjectTypeAsIPoolable;
                }
            }
            else // the pooler does NOT have the type pool
            {
                // create the pool
                Dictionary<IPoolable, bool> newTypeDictionary = new Dictionary<IPoolable, bool>();
                pooler.pools.Add(objectType, newTypeDictionary);
                // create new object
                IPoolable newObjectTypeAsIPoolable = (IPoolable)Activator.CreateInstance(objectType);
                // pool the new object
                newTypeDictionary.Add(newObjectTypeAsIPoolable, true);
                // return the new object
                return newObjectTypeAsIPoolable;
            }
        }

        public static string RemovePoolable(ObjectPooler pooler, IPoolable removable)
        {
            // get the type of the object that is to be removed
            Type objectType = removable.GetType();
            // check if the pool exists
            if (pooler.pools.ContainsKey(objectType)) // the pooler contains the type pool
            {
                // check if the object exists
                if (pooler.pools[objectType].ContainsKey(removable)) // the pool contains the object
                {
                    // check if the object is active
                    if (pooler.pools[objectType][removable] == true) // the object is active
                    {
                        // deactivate object
                        pooler.pools[objectType][removable] = false;
                    }
                    else // the object is not active
                    {
                        return $"The object is not active ({removable.ToString()})";
                    }
                }
                else
                {
                    return $"No such object in the pools ({removable.ToString()})";
                }
            }
            else // the pool does not contain the pool type
            {
                return $"There is no pool for the object ({removable.ToString()})";
            }

            return String.Empty; // default return
        }

        public static List<IPoolable> ListPooledObjects(ObjectPooler pooler, Type objectType, bool activeOnly)
        {
            // check if there is a pool of the corresponding type
            if (pooler.pools.ContainsKey(objectType))
            {
                List<IPoolable> resultList = new List<IPoolable>();
                foreach (var item in pooler.pools[objectType])
                {
                    if (item.Value == activeOnly || activeOnly == false)
                    {
                        resultList.Add(item.Key);
                    }
                }
                return resultList;
            }
            else
            {
                return null;
            }

            // TODO : HERE
        }
    }
}
