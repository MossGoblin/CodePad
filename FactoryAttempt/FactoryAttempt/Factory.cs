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

        public static string RemoveBulkObjects(ObjectPooler pooler, int toBeRemoved)
        {
            // check if there is such a pool
            Type objectType = typeof(T);
            if (pooler.pools.ContainsKey(objectType)) // there is such a type pool
            {
                // get the number count for that type pool
                int objectCount = pooler.pools[objectType].Count;
                int numberOfDecativations = Math.Min(toBeRemoved, objectCount);
                // deactivate 'numberOfDecativations' number of objects
                foreach (var objectOfType in pooler.pools[objectType]) // TODO : HERE - should NOT foreach
                {
                    if (numberOfDecativations > 0 && objectOfType.Value == true) // if the object is active
                    {
                        IPoolable item = objectOfType.Key;
                        // deavtivate object
                        pooler.pools[objectType][item] = false;
                        numberOfDecativations--;
                    }
                }
                return $"Removed {toBeRemoved} objects of type {objectType.Name}";
            }
            else
            {
                return $"Type {objectType.Name} note present in the pools";
            }


            return String.Empty;
        }

        public static List<IPoolable> ListPooledObjects(ObjectPooler pooler, Type objectType, bool inactive)
        {
            // check if there is such a type
            // convert the pool into a list (? including inactive)
            return null;
        }
    }
}
