using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelper.Mathematics
{
    public class MathMoving
    {
        /// <summary>Use function to moves object by circle</summary>
        /// <param name="center">Center of moving</param>
        /// <param name="radius">Moving radius</param>
        /// <returns>Point in enviroment by time</returns>
        public static Vector3 MoveByCircle(Vector3 center, float radius, float time)
        {
            time = Mathf.Clamp01(time);
            float angle = time * 2 * Mathf.PI;
            float x = center.x + radius * Mathf.Cos(angle);
            float y = center.y + radius * Mathf.Sin(angle);
            return new Vector3(x, y);
        }

        /// <summary> Use this function to move object by curve of given points</summary>
        /// <param name="points">Traectory of moving</param>
        /// <param name="time">Time, value between 0,1</param>
        /// <returns>Retruns the point of way by time</returns>
        /// <exception cref="ArgumentException">points count must be more then 2</exception>
        public static Vector3 BezieMove(List<Vector3> points, float time, bool withSmoothBack)
        {
            if (points.Count < 2) throw new ArgumentException("List count must be more then 2");
            if (withSmoothBack) points.Add(points.First());
            while (points.Count > 1)
            {
                List<Vector3> tempPoints = new();
                for (int i = 0; i < points.Count - 1; i++)
                {
                    Vector3 newPos = Vector3.Lerp(points[i], points[i + 1], time);
                    tempPoints.Add(newPos);
                }
                points = tempPoints;
            }
            return points[0];
        }

        /// <summary>Use this function to turn in direction </summary>
        /// <param name="way">Way of moving </param>
        /// <param name="time">Time, value between 0,1</param>
        /// <returns>Direction of move by time</returns>
        public static Vector3 FirstDerivative(List<Vector3> way, float time)
        {
            var n = way.Count - 1;
            Vector3 result = Vector3.zero;
            for (int i = 0; i < n; i++)result += n * (way[i + 1] - way[i]) * Bernstein(n - 1, i, time);
            return result;
        }

        /// <summary>Used to move an object in a straight line through all points in the collection </summary>
        public static Vector3 MoveByPolygon(List<Vector3> points, float time, bool withSmoothBack = false)
        {
            if (points.Count < 2) throw new ArgumentException("The list of points should contain at least two points for movement.");
            if (withSmoothBack) points.Add(points.First());

            var totalPathLength = CalculateTotalPathLength(points);
            var dist = time * totalPathLength;
            var cumulativeDistance = 0f;
            for (int i = 0; i < points.Count - 1; i++)
            {
                Vector3 p0 = points[i];
                Vector3 p1 = points[i + 1];
                var segmentLength = Vector3.Distance(p0, p1);
                var newDistance = cumulativeDistance + segmentLength;

                if (newDistance >= dist)
                {
                    var t = Mathf.InverseLerp(cumulativeDistance, newDistance, dist);
                    return Vector3.Lerp(p0, p1, t);
                }
                cumulativeDistance = newDistance;
            }

            return points[^1];
        }

        private static float CalculateTotalPathLength(List<Vector3> points)
        {
            float totalLength = 0f;
            for (int i = 0; i < points.Count - 1; i++) totalLength += Vector3.Distance(points[i], points[i + 1]);
            return totalLength;
        }

        private static float Bernstein(int n, int i, float t) =>
            BinomialCoefficient(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        
        private static int BinomialCoefficient(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            if (k == 0 || k == n) return 1;
            k = Math.Min(k, n - k);
            int c = 1;
            for (int i = 0; i < k; i++) c = c * (n - i) / (i + 1);
            
            return c;
        }
    }
}
