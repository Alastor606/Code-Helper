using System;
using System.Collections.Generic;
using static UnityEditor.Progress;

namespace CodeHelper
{
    public static class ListExtentions
    {
        /// <returns> True if list is empty </returns>
        public static bool IsEmpty<T>(this IList<T> self) => self.Count == 0;

        /// <returns> First object of collestion </returns>
        public static T First<T>(this IList<T> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            return self[0];
        }

        /// <returns> Last object of collestion </returns>
        public static T Last<T>(this IList<T> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            return self[^1];
        }

        /// <returns> Random value of collection </returns>
        public static T GetRandom<T>(this IList<T> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            return self[UnityEngine.Random.Range(0, self.Count)];
        }

        /// <summary> Find equals your`s gameObjcts </summary>
        /// <returns> Count of Equal objects</returns>
        public static int GetEqualsCount<T>(this IList<T> self, T obj)
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
        public static T GetEqualOrFirst<T>(this IList<T> self, T reference)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            if (self.Contains(reference)) return self[self.IndexOf(reference)];
            else return self.First();
        }

        /// <summary> 
        /// All objects in collection invokes action 
        /// <br/><br/>Note :<br/>Does not change the reference value of structures such as : int, float<br/>
        /// But change values in class such as Wallet.Add(14) and so on
        /// </summary>
        public static void AllDo<T>(this IList<T> self, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach(var item in self) action(item);
        }

        /// <summary> All objects in collection except one invokes action  </summary>
        public static void AllDoWithout<T>(this IList<T> self, Action<T> action, T exception)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (var item in self)
            {
                if (item.Equals(exception)) continue;
                action(item);
            }
        }

        /// <summary> All objects in collection except list invokes action  </summary>
        public static void AllDoWithout<T>(this IList<T> self, Action<T> action, IList<T> exceptions)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (var item in self)
            {
                if (exceptions.Contains(item)) continue;
                action(item);
            }
        }

        /// <summary> One object by index, invokes action  </summary>
        public static void SingleDo<T>(this IList<T> self, int index, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            if (self.Count < index) throw new ArgumentOutOfRangeException($"Index out of range : {index}, list count : {self.Count}");
            action(self[index]);
        }

        /// <summary> One object by link, invokes action  </summary>
        public static void SingleDo<T>(this IList<T> self, T obj, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            if (!self.Contains(obj)) throw new ArgumentException($"List has no {obj}");
            action(self[self.IndexOf(obj)]);
        }


        /// <summary>Replaces old value to new </summary>
        /// <param name="oldValue">Value to replace</param>
        /// <param name="newValue">Value replace to</param>
        public static void Replace<T>(this IList<T> self, T oldValue, T newValue)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is emty");
            if (!self.Contains(oldValue)) throw new ArgumentException("List has no equal values");
            self[self.IndexOf(oldValue)] = newValue;
        }

        /// <summary>Replace all values in collection to new </summary>
        public static void ReplaceAll<T>(this IList<T> self, T newValue)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is emty");
            for (int i = 0; i < self.Count; i++) self[i] = newValue;
        }

        /// <summary>Replaces range of collection to new Value </summary>
        public static void ReplaceRange<T>(this IList <T> self, int startIndex, T newValue, int lastIndex = -1)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is emty");
            if ((startIndex | lastIndex) >= self.Count) throw new ArgumentException("Indexes must be less then list count");
            if ((startIndex | lastIndex) < 0 && lastIndex != -1) throw new ArgumentException("Indexes must be more then zero");

            if (lastIndex == -1) lastIndex = self.Count;
            for (int i = startIndex; i < lastIndex; i++) self[i] = newValue;
        }

        /// <summary> </summary>
        /// <param name="startIndex">Index of item when starts replasing</param>
        /// <param name="newValue">Value replace to</param>
        public static void ReplaceRangeFromEnd<T>(this IList<T> self, int startIndex, T newValue, int lastIndex = -1)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is emty");
            if ((startIndex | lastIndex) >= self.Count) throw new ArgumentException("Indexes must be less then list count");
            if ((startIndex | lastIndex) < 0 && lastIndex != -1) throw new ArgumentException("Indexes must be more then zero");

            if (lastIndex == -1) lastIndex = 0;
            for (int i = self.Count - 1- startIndex; i >= lastIndex; i--) self[i] = newValue;
        }


        /// <summary>Swaps first and second values </summary>
        public static void Swap<T>(this IList<T> self, T firstValue, T secondValue)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is emty");
            if (!self.Contains(firstValue) || !self.Contains(secondValue)) throw new ArgumentException("List doesnt contains given values");

            var value = firstValue;
            var secondIndex = self.IndexOf(secondValue);
            self[self.IndexOf(firstValue)] = secondValue;
            self[secondIndex] = value;
        }
    }
}

namespace CodeHelper.Unity
{
    using UnityEngine;
    public static class ListExtentions
    {
        /// <summary> Turn`s off all GameObjects in colliction </summary>
        public static void Off<T>(this IList<T> self) where T : Component
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (Component comp in self) comp.gameObject.SetActive(false);
        }

        /// <summary> Turn`s on all GameObjects in colliction </summary>
        public static void On<T>(this IList<T> self) where T : Component
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (Component comp in self) comp.gameObject.SetActive(true);
        }

        /// <summary> Turn`s off all GameObjects in colliction </summary>
        public static void Off(this IList<GameObject> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (GameObject comp in self) comp.SetActive(false);
        }

        /// <summary> Turn`s on all GameObjects in colliction </summary>
        public static void On(this IList<GameObject> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (GameObject comp in self) comp.SetActive(true);
        }

        public static List<Vector3> GetPositions(this IList<Transform> self)
        {
            var vectorsList = new List<Vector3>();
            foreach (var item in self) vectorsList.Add(item.position);
            return vectorsList;
        }
    }
}
