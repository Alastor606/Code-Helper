using UnityEngine;

namespace CodeHelper.Unity
{
    public static class QuaternionExtentions
    {
        public static Quaternion Zero(this Quaternion self) => new(0, 0, 0, 0);
    }
}

