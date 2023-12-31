using System;
using System.Collections.Generic;

namespace CodeHelper
{
    public static class ListExtentions
    {
        /// <returns> True if list is empty </returns>
        public static bool IsEmpty<T>(this List<T> self) => self.Count == 0;

        /// <returns> First object of collestion </returns>
        public static T First<T>(this List<T> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            return self[0];
        }

        /// <returns> Last object of collestion </returns>
        public static T Last<T>(this List<T> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            return self[^1];
        }

        /// <returns> Random value of collection </returns>
        public static T GetRandom<T>(this List<T> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            return self[UnityEngine.Random.Range(0, self.Count)];
        }

        /// <summary> Find equals your`s gameObjcts </summary>
        /// <returns> Count of Equal objects</returns>
        public static int GetEqualsCount<T>(this List<T> self, T obj)
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
        public static T GetEqualsOrFirst<T>(this List<T> self, T reference)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            if (self.Contains(reference)) return self[self.IndexOf(reference)];
            else return self.First();
        }

        /// <summary> All objects in collection invokes action </summary>
        public static void AllDo<T>(this List<T> self, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (var item in self) action(item);
        }

        /// <summary> All objects in collection except one invokes action  </summary>
        public static void AllDoWithout<T>(this List<T> self, Action<T> action, T exception)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (var item in self)
            {
                if (item.Equals(exception)) continue;
                action(item);
            }
        }

        /// <summary> All objects in collection except list invokes action  </summary>
        public static void AllDoWithout<T>(this List<T> self, Action<T> action, List<T> exceptions)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (var item in self)
            {
                if (exceptions.Contains(item)) continue;
                action(item);
            }
        }

        /// <summary> One object by index, invokes action  </summary>
        public static void SingleDo<T>(this List<T> self, int index, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            if (self.Count < index) throw new ArgumentOutOfRangeException($"Index out of range : {index}, list count : {self.Count}");
            action(self[index]);
        }

        /// <summary> One object by link, invokes action  </summary>
        public static void SingleDo<T>(this List<T> self, T obj, Action<T> action)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            if (!self.Contains(obj)) throw new ArgumentException($"List has no {obj}");
            action(self[self.IndexOf(obj)]);
        }
    }
}

namespace CodeHelper.Unity
{
    using UnityEngine;
    public static class ListExtentions
    {
        /// <summary> Turn`s off all GameObjects in colliction </summary>
        public static void Off<T>(this List<T> self) where T : Component
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (Component comp in self) comp.gameObject.SetActive(false);
        }

        /// <summary> Turn`s on all GameObjects in colliction </summary>
        public static void On<T>(this List<T> self) where T : Component
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (Component comp in self) comp.gameObject.SetActive(true);
        }

        /// <summary> Turn`s off all GameObjects in colliction </summary>
        public static void Off(this List<GameObject> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (GameObject comp in self) comp.SetActive(false);
        }

        /// <summary> Turn`s on all GameObjects in colliction </summary>
        public static void On(this List<GameObject> self)
        {
            if (self.IsEmpty()) throw new ArgumentNullException("List is empty");
            foreach (GameObject comp in self) comp.SetActive(true);
        }
    }
}
