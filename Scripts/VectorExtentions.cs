using UnityEngine;

namespace CodeHelper.Unity
{
    public static class VectorExtentions
    {
        /// <returns> Copy of Vector3 to Vector2</returns>
        public static Vector2 ToV2(this Vector3 self) => (Vector2)self;

        /// <returns> Copy of Vector2 to Vector3 with z = 0</returns>
        public static Vector3 ToV3(this Vector2 self) => self;
        ///  <returns> ints vector</returns>
        public static Vector3Int ToVInt(this Vector3 vector)
        {
            return new Vector3Int
            {
                x = Mathf.FloorToInt(vector.x),
                y = Mathf.FloorToInt(vector.y),
                z = Mathf.FloorToInt(vector.z)
            };
        }

        /// <summary> Set X of vector </summary>
        public static void SetX(this Vector3 self, float x) => self.x = x;

        /// <summary> Set Y of vector </summary>
        public static void SetY(this Vector3 self, float y) => self.y = y;

        /// <summary> Set Y of vector </summary>
        public static void SetZ(this Vector3 self, float z) => self.z = z;

    }
}

