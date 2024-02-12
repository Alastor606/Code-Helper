using UnityEngine;

namespace CodeHelper.Unity
{
    internal static class QuaternionExtentions
    {
        internal static Quaternion Zero(this Quaternion self) => new(0, 0, 0, 0);
    }
}

