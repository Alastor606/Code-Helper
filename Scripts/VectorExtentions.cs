using UnityEngine;

namespace CodeHelper.Unity
{
    internal static class VectorExtentions
    {
        /// <returns> Copy of Vector3 to Vector2</returns>
        internal static Vector2 ToV2(this Vector3 self) => (Vector2)self;

        /// <returns> Copy of Vector2 to Vector3 with z = 0</returns>
        internal static Vector3 ToV3(this Vector2 self) => self;
        ///  <returns> ints vector</returns>
        internal static Vector3Int ToVInt(this Vector3 vector)
        {
            return new Vector3Int
            {
                x = Mathf.FloorToInt(vector.x),
                y = Mathf.FloorToInt(vector.y),
                z = Mathf.FloorToInt(vector.z)
            };
        }

        internal static Vector2 Add(ref this Vector2 self, int value)
        {
            self.x += value;
            self.y += value;
            return self;
        }
        
        internal static Vector2 Remove(ref this Vector2 self, int value)
        {
            self.x -= value;
            self.y -= value;
            return self;
        }

        internal static Vector2 Add(ref this Vector2 self, float value)
        {
            self.x += value;
            self.y += value;
            return self;
        }
        
        internal static Vector2 Remove(ref this Vector2 self, float value)
        {
            self.x -= value;
            self.y -= value;
            return self;
        }
        
        internal static bool MoreThen(this Vector2 self, Vector2 value)
        {
            if (self.x > value.x && self.y > value.y) return true;
            else return false;
        }

        internal static Vector2 Init(this Vector2 self, float value) => new (value, value);
        internal static Vector3 Init(this Vector3 self, float value) => new(value, value, value);

        /// <summary> Set X of vector </summary>
        internal static void SetX(this Vector3 self, float x) => self.x = x;

        /// <summary> Set Y of vector </summary>
        internal static void SetY(this Vector3 self, float y) => self.y = y;

        /// <summary> Set Y of vector </summary>
        internal static void SetZ(this Vector3 self, float z) => self.z = z;

    }
}

