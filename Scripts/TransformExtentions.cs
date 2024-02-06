using System.Collections.Generic;
using UnityEngine;

namespace CodeHelper.Unity
{
    using CodeHelper.Mathematics;
    public static class TransformExtentions
    {
        /// <returns> True if transform has child gameObjects </returns>
        public static bool HasChildren<T>(this T self) where T : Transform =>
            self.childCount > 0;

         public static bool HasChildren(this GameObject self) =>
             self.transform.childCount > 0;

        /// <summary> Add children gameObject to transform </summary>
        public static T Add<T>(this Transform self, T additional) where T : Object =>
            Object.Instantiate(additional, self);
        
        /// <summary> Add list of object to children of transform </summary>
        public static void Add<T>(this Transform self, List<T> additional) where T : Object
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

        /// <summary>Moves transform by bezier points</summary>
        /// <param name="way">Points to move there</param>
        /// <param name="time">value between 0 and 1 to move from fist to last points in way</param>
        public static void MoveByCurve<T>(this T self, List<Transform> way, float time, bool withRotation = false, bool withSmoothBack = false) where T : Transform
        {
            self.position = MathMoving.BezieMove(way.GetPositions(), time, withSmoothBack);
            if(withRotation) self.rotation = Quaternion.LookRotation(MathMoving.FirstDerivative(way.GetPositions(), time));
        }

        /// <summary>Moves transform by polygons </summary>
        /// <param name="way">Points to move there</param>
        /// <param name="time">value between 0 and 1 to move from fist to last points in way</param>
        public static void MoveByPolygon<T>(this T self, List<Transform> way, float time, bool withSmoothBack = false) where T : Transform =>
            self.position = MathMoving.MoveByPolygon(way.GetPositions(), time, withSmoothBack);

        public static void MoveByCircle<T>(this T self, float radius, float time) where T : Transform =>
            self.position = MathMoving.MoveByCircle(self.position, radius, time);
        
    }
}

