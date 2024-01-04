using UnityEngine;

namespace CodeHelper.Mathematics
{
    public static class CircleMove
    {
        public static Vector3 MoveByCircle(Vector3 center, float radius, float t)
        {
            t = Mathf.Clamp01(t);
            float angle = t * 2 * Mathf.PI;
            float x = center.x + radius * Mathf.Cos(angle);
            float y = center.y + radius * Mathf.Sin(angle);
            return new Vector3(x, y);
        }

    }
}

