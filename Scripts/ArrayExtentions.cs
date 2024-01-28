using System;

namespace CodeHelper
{
    public static class ArrayExtentions
    {
        /// <returns>First object of collection</returns>
        public static T First<T>(this T[] self) => self[0];

        /// <returns>Last object of collection</returns>
        public static T Last<T>(this T[] self) => self[^1];

        /// <summary>Check collection length</summary>
        /// <returns>True if collection is empty</returns>
        public static bool IsEmpty<T>(this T[] self)
        {
            if (self.Length < 1 || self[0] == null) return true;
            return false;
        }

        /// <returns> Random value of collection </returns>
        public static T GetRandom<T>(this T[] self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("array is empty");
            return self[UnityEngine.Random.Range(0, self.Length - 1)];
        }

        /// <summary> Find equals your`s gameObjcts </summary>
        /// <returns> Count of Equal objects</returns>
        public static int GetEqualsCount<T>(this T[] self, T obj)
        {
            int index = 0;
            foreach (var item in self)
            {
                if (item.Equals(obj)) index++;
            }
            if (index > 0) return index;
            else return -1;
        }

        /// <summary> Find equals your`s gameObjcts </summary>
        /// <returns> Object of collection equal yours if collection contains this, else returns the first object</returns>
        public static T GetEqualsOrFirst<T>(this T[] self, T reference)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("array is empty");
            foreach(var item in self) if(item.Equals(reference))return item;
            
            return self.First();
        }

        /// <summary> All objects in collection invokes action </summary>
        public static void AllDo<T>(this T[] self, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("array is empty");
            foreach (var item in self) action(item);
        }

        /// <summary> All objects in collection except one invokes action  </summary>
        public static void AllDoWithout<T>(this T[] self, Action<T> action, T exception)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("array is empty");
            if (!self.Contains(exception)) throw new ArgumentException("Array didnt contains exteption object");
            foreach (var item in self)
            {
                if (item.Equals(exception)) continue;
                action(item);
            }
        }

        /// <summary> All objects in collection except list invokes action  </summary>
        public static void AllDoWithout<T>(this T[] self, Action<T> action, T[] exceptions)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("array is empty");
            if (!self.Equals(exceptions)) throw new ArgumentException($"Array didnt equal {exceptions}");

            foreach (var item in self)
            {
                if (exceptions.Contains(item)) continue;
                action(item);
            }
        }

        /// <summary> One object by index, invokes action  </summary>
        public static void SingleDo<T>(this T[] self, int index, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("array is empty");
            if (self.Length < index) throw new ArgumentOutOfRangeException($"Index out of range : {index}, array count : {self.Length}");
            action(self[index]);
        }

        /// <summary> One object by link, invokes action  </summary>
        public static void SingleDo<T>(this T[] self, T obj, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("Array is empty");
            if (!self.Contains(obj)) throw new ArgumentException($"Array didnt contains {obj}");

            foreach(var item in self) if (item.Equals(obj)) action(obj);
        }

        /// <summary>Replace old value to new value</summary>
        /// <param name="oldValue">The value you want to replace</param>
        /// <param name="newValue">The value you want to change to</param>
        /// <returns>Replaced array</returns>
        public static T[] Replace<T>(this T[] self, T oldValue, T newValue)
        {
            if (!self.Contains(oldValue)) throw new ArgumentException($"There is no {oldValue} in array");
            if (!self.Contains(newValue)) throw new ArgumentException($"There is no {newValue} in array");

            var replacedArray = new T[self.Length];
            for(int i = 0; i < self.Length; i++)
            {
                if (self[i].Equals(oldValue)) replacedArray[i] = newValue;
                else replacedArray[i] = self[i];
            }
            return replacedArray;
        }

        /// <summary>Swaps the values </summary>
        /// <param name="firstValue">Swap value</param>
        /// <param name="secondValue">Swap value</param>
        /// <returns>Swapped array</returns>
        public static T[] Swap<T>(this T[] self, T firstValue, T secondValue)
        {
            if (!self.Contains(firstValue)) throw new ArgumentException($"There is no {firstValue} in array") ;
            if (!self.Contains(secondValue)) throw new ArgumentException($"There is no {secondValue} in array");

            var swappedArray = new T[self.Length];
            for (int i = 0; i < self.Length; i++) 
            {
                if (firstValue.Equals(self[i])) swappedArray[i] = secondValue;
                else if (secondValue.Equals(self[i])) swappedArray[i] = firstValue;
                else swappedArray[i] = self[i];
            }
            return swappedArray;
        }

        /// <summary> Checks if a value is stored there</summary>
        /// <returns>True if contains</returns>
        public static bool Contains<T>(this T[] self, T value)
        {
            foreach (var item in self)if (item.Equals(value)) return true;
            return false;
        }

        public static bool Contains<T>(this T[] self, T value, out int index)
        {
            for (int i = 0; i < self.Length - 1; i++)
            {
                if (self[i].Equals(value))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        /// <summary>If self has all values of container returns true</summary>
        /// <param name="container">Given container to compare</param>
        public static bool Equals<T>(this T[] self, T[] container)
        {
            if (container.Length > self.Length) throw new ArgumentException("Container length can`t be longer then current array length");

            int index = 0;
            for (int i = 0; i < container.Length; i++)
            {
                for (int j = 0; j < container.Length; j++)
                {
                    if (self[i].Equals(container[j]))
                    {
                        index++;
                        break;
                    }
                }  
            }
            if(index == container.Length) return true;
            return false;
        }

        /// <summary>Reverse array </summary>
        /// <returns>Reversed array</returns>
        public static T[] Reverse<T>(this T[] self)
        {
            var length = self.Length;
            var reversed = new T[length];
            for (int i = 0; i < length; i++) reversed[i] = self[length - i - 1];
            
            return reversed;
        }
    }
}

