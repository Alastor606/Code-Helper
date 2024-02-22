using UnityEngine;

namespace CodeHelper.Unity
{
    internal static class QuaternionExtentions
    {
        internal static Quaternion SetZero(ref this Quaternion self) => self = Quaternion.Euler(0,0,0);
    }
}

