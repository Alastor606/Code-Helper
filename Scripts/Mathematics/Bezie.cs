using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeHelper.Mathematics
{
    public static class Bezie
    {
        public static Vector3 GetPoint(List<Vector3> points, float time)
        {
            if (points.Count < 2) throw new ArgumentException("List count must be more then 2");
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

        public static Vector3 GetFirstDerivative(List<Vector3> controlPoints, float t)
        {
            t = Mathf.Clamp01(t);
            int degree = controlPoints.Count - 1;
            float oneMinusT = 1f - t;
            Vector3 derivative = Vector3.zero;

            for (int i = 0; i < degree; i++)
                derivative += BinomialCoefficient(degree, i) * Mathf.Pow(oneMinusT, degree - i) * Mathf.Pow(t, i) * controlPoints[i + 1] - controlPoints[i];

            derivative *= degree;
            return derivative;
        }

        private static int BinomialCoefficient(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            int coeff = 1;
            for (int i = 1; i <= k; i++)
            {
                coeff *= n - (k - i);
                coeff /= i;
            }
            return coeff;
        }
    }
}

