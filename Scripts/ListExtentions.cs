using System;
using System.Collections.Generic;

namespace CodeHelper
{
    internal static class ListExtentions
    {
        private readonly static ArgumentException MainEx = new ("List is empty");
        /// <returns> True if list is empty </returns>
        internal static bool IsEmpty<T>(this IList<T> self) => self.Count == 0;

        /// <returns> First object of collestion </returns>
        internal static T First<T>(this IList<T> self)
        {
            if (self.IsEmpty()) throw MainEx;
            return self[0];
        }

        /// <returns> Last object of collestion </returns>
        internal static T Last<T>(this IList<T> self)
        {
            if (self.IsEmpty()) throw MainEx;
            return self[^1];
        }

        /// <returns> Random value of collection </returns>
        internal static T GetRandom<T>(this IList<T> self)
        {
            if (self.IsEmpty()) throw MainEx;
            return self[UnityEngine.Random.Range(0, self.Count)];
        }

        /// <summary> Find equals your`s gameObjcts </summary>
        /// <returns> Count of Equal objects</returns>
        internal static int GetEqualsCount<T>(this IList<T> self, T obj)
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
        internal static T GetEqualOrFirst<T>(this IList<T> self, T reference)
        {
            if (self.IsEmpty()) throw MainEx;
            if (self.Contains(reference)) return self[self.IndexOf(reference)];
            else return self.First();
        }

        /// <summary> 
        /// All objects in collection invokes action 
        /// <br/><br/>Note :<br/>Does not change the reference value of structures such as : int, float<br/>
        /// But change values in class such as Wallet.Add(14) and so on
        /// </summary>
        internal static void AllDo<T>(this IList<T> self, Action<T> action) 
        {
            if (self.IsEmpty()) throw MainEx;
            foreach(var item in self) action.Invoke(item);
        }

        /// <summary> All objects in collection except one invokes action  </summary>
        internal static void AllDoWithout<T>(this IList<T> self, Action<T> action, T exception)
        {
            if (self.IsEmpty()) throw MainEx;
            if (!self.Contains(exception)) throw new ArgumentException($"Array doesnt contains {exception}") ;

            foreach (var item in self)
            {
                if (item.Equals(exception)) continue;
                action(item);
            }
        }

        /// <summary> All objects in collection except list invokes action  </summary>
        internal static void AllDoWithout<T>(this IList<T> self, Action<T> action, IList<T> exceptions)
        {
            if (self.IsEmpty()) throw MainEx;
            foreach (var item in self)
            {
                if (exceptions.Contains(item)) continue;
                action(item);
            }
        }

        /// <summary> One object by index, invokes action  </summary>
        internal static void SingleDo<T>(this IList<T> self, int index, Action<T> action)
        {
            if (self.IsEmpty()) throw MainEx;
            if (self.Count < index) throw new ArgumentOutOfRangeException($"Index out of range : {index}, list count : {self.Count}");
            action(self[index]);
        }

        /// <summary> One object by link, invokes action  </summary>
        internal static void SingleDo<T>(this IList<T> self, T obj, Action<T> action)
        {
            if (self.IsEmpty()) throw MainEx;
            if (!self.Contains(obj)) throw new ArgumentException($"List has no {obj}");
            action(self[self.IndexOf(obj)]);
        }


        /// <summary>Replaces old value to new </summary>
        /// <param name="oldValue">Value to replace</param>
        /// <param name="newValue">Value replace to</param>
        internal static void Replace<T>(this IList<T> self, T oldValue, T newValue)
        {
            if (self.IsEmpty()) throw MainEx;
            if (!self.Contains(oldValue)) throw new ArgumentException("List has no equal values");
            self[self.IndexOf(oldValue)] = newValue;
        }

        /// <summary>Replace all values in collection to new </summary>
        internal static void ReplaceAll<T>(this IList<T> self, T newValue)
        {
            if (self.IsEmpty()) throw MainEx;
            for (int i = 0; i < self.Count; i++) self[i] = newValue;
        }

        /// <summary>Replaces range of collection to new Value </summary>
        internal static void ReplaceRange<T>(this IList <T> self, int startIndex, T newValue, int lastIndex = -1)
        {
            if (self.IsEmpty()) throw MainEx;
            if ((startIndex | lastIndex) >= self.Count) throw new ArgumentException("Indexes must be less then list count");
            if ((startIndex | lastIndex) < 0 && lastIndex != -1) throw new ArgumentException("Indexes must be more then zero");

            if (lastIndex == -1) lastIndex = self.Count;
            for (int i = startIndex; i < lastIndex; i++) self[i] = newValue;
        }

        /// <summary> </summary>
        /// <param name="startIndex">Index of item when starts replasing</param>
        /// <param name="newValue">Value replace to</param>
        internal static void ReplaceRangeFromEnd<T>(this IList<T> self, int startIndex, T newValue, int lastIndex = -1)
        {
            if (self.IsEmpty()) throw MainEx;
            if ((startIndex | lastIndex) >= self.Count) throw new ArgumentException("Indexes must be less then list count");
            if ((startIndex | lastIndex) < 0 && lastIndex != -1) throw new ArgumentException("Indexes must be more then zero");

            if (lastIndex == -1) lastIndex = 0;
            for (int i = self.Count - 1- startIndex; i >= lastIndex; i--) self[i] = newValue;
        }

        /// <summary>Swaps first and second values </summary>
        internal static void Swap<T>(this IList<T> self, T firstValue, T secondValue)
        {
            if (self.IsEmpty()) throw MainEx;
            if (!self.Contains(firstValue) || !self.Contains(secondValue)) throw new ArgumentException("List doesnt contains given values");

            var value = firstValue;
            var secondIndex = self.IndexOf(secondValue);
            self[self.IndexOf(firstValue)] = secondValue;
            self[secondIndex] = value;
        }

        internal static T Where<T>(this IList<T> self, Func<T, bool> predicate)
        {
            foreach (var item in self) if (predicate(item)) return item;
            throw new ArgumentException("There are no objects in this collection that match the given condition");
        }
    }
}

namespace CodeHelper.Unity
{
    using UnityEngine;
    internal static class ListExtentions
    {
        private static readonly ArgumentException MainEx = new("List is empty");
        /// <summary> Turn`s off all GameObjects in colliction </summary>
        internal static void Off<T>(this IList<T> self) where T : Component
        {
            if (self.IsEmpty()) throw MainEx;
            foreach (Component comp in self) comp.gameObject.SetActive(false);
        }

        /// <summary> Turn`s on all GameObjects in colliction </summary>
        internal static void On<T>(this IList<T> self) where T : Component
        {
            if (self.IsEmpty()) throw MainEx;
            foreach (Component comp in self) comp.gameObject.SetActive(true);
        }

        /// <summary> Turn`s off all GameObjects in colliction </summary>
        internal static void Off(this IList<GameObject> self)
        {
            if (self.IsEmpty()) throw MainEx;
            foreach (GameObject comp in self) comp.SetActive(false);
        }

        /// <summary> Turn`s on all GameObjects in colliction </summary>
        internal static void On(this IList<GameObject> self)
        {
            if (self.IsEmpty()) throw MainEx;
            foreach (GameObject comp in self) comp.SetActive(true);
        }

        /// <returns>The array of given tramsforms positions</returns>
        internal static List<Vector3> GetPositions(this IList<Transform> self)
        {
            var vectorsList = new List<Vector3>();
            foreach (var item in self) vectorsList.Add(item.position);
            return vectorsList;
        }
    }
}
