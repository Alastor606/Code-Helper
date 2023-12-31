using System.Collections.Generic;
using UnityEngine;

namespace CodeHelper.Unity
{
    public static class TransformExtentions
    {
        /// <returns> True if transform has child gameObjects </returns>
        public static bool HasChildren<T>(this T self) where T : Transform =>
            self.childCount > 0;

        /// <summary> Add children gameObject to transform </summary>
        public static GameObject Add<T>(this T self, GameObject additional) where T : Transform =>
            Object.Instantiate(additional, self);

        /// <summary> Add list of object to children of transform </summary>
        public static void Add<T>(this T self, List<GameObject> additional) where T : Transform
        {
            foreach (var item in additional) Object.Instantiate(item, self);
        }

        /// <summary> Destroy all child gameObjects</summary>
        public static bool Clear<T>(this T self) where T : Transform
        {
            foreach (Transform child in self) Object.Destroy(child.gameObject);
            if (self.HasChildren()) return false;
            else return true;
        }
    }
}

