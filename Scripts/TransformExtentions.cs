namespace CodeHelper.Unity
{
    using UnityEngine;
    using CodeHelper.Mathematics;
    using System.Collections.Generic;
    using System.Linq;

    internal static class TransformExtentions
    {
        /// <returns> True if transform has child gameObjects </returns>
        internal static bool HasChildren<T>(this T self) where T : Transform =>
            self.childCount > 0;

        /// <returns> True if transform has child gameObjects </returns>
        internal static bool HasChildren(this GameObject self) =>
             self.transform.childCount > 0;

        /// <returns>False if ALL transforms doesnt have child</returns>
        internal static bool HasChildren<T>(this IEnumerable<T> self) where T : Transform
        {
            int index = 0;
            foreach(T item in self)if (item.HasChildren()) index++;
            return index == self.Count();
        }

        /// <summary> Add children gameObject to transform </summary>
        internal static T Add<T>(this Transform self, T additional) where T : Object =>
            Object.Instantiate(additional, self);
        
        /// <summary> Add list of object to children of transform </summary>
        internal static void Add<T>(this Transform self, List<T> additional) where T : Object
        {
            foreach (var item in additional) Object.Instantiate(item, self);
        }

        /// <summary> Destroy all child gameObjects</summary>
        internal static bool Clear<T>(this T self) where T : Transform
        {
            foreach (Transform child in self) Object.Destroy(child.gameObject);
            return !self.HasChildren();
        }

        /// <summary>Moves transform by bezier points</summary>
        /// <param name="way">Points to move there</param>
        /// <param name="time">value between 0 and 1 to move from fist to last points in way</param>
        internal static void MoveByCurve<T>(this T self, List<Transform> way, float time, bool withRotation = false, bool withSmoothBack = false) where T : Transform
        {
            self.position = MathMoving.BezieMove(way.GetPositions(), time, withSmoothBack);
            if(withRotation) self.rotation = Quaternion.LookRotation(MathMoving.FirstDerivative(way.GetPositions(), time));
        }

        /// <summary>Moves transform by polygons </summary>
        /// <param name="way">Points to move there</param>
        /// <param name="time">value between 0 and 1 to move from fist to last points in way</param>
        internal static void MoveByPolygon<T>(this T self, List<Transform> way, float time, bool withSmoothBack = false) where T : Transform =>
            self.position = MathMoving.MoveByPolygon(way.GetPositions(), time, withSmoothBack);


        /// <summary>Moves transform by 2d Circle </summary>
        /// <param name="radius"></param>
        /// <param name="time"></param>
        internal static void MoveByCircle<T>(this T self, float radius, float time, Transform center) where T : Transform
        {
            if(self != null)self.position = MathMoving.MoveByCircle(center.position, radius, time);
        }

        /// <summary>Moves transform by 2d Circle </summary>
        /// <param name="radius"></param>
        /// <param name="time"></param>
        internal static void MoveByCircle<T>(this T self, float radius, float time, Vector3 center) where T : Transform
        {
            if (self != null) self.position = MathMoving.MoveByCircle(center, radius, time);
        }
            
    }
}

