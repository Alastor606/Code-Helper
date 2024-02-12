namespace CodeHelper.Unity
{
    using System;
    using System.Collections;
    using UnityEngine;
    internal static class MonoExtentions
    {

        /// <summary>Starts local coroutine, wait given time and invoke action </summary>
        /// <param name="time">Delay</param>
        internal static void WaitAndDo(this MonoBehaviour self, float delay, Action toDo)
        {
            self.StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(delay);
                toDo.Invoke();
            }
        }

        /// <summary>Instanse object with given params</summary>
        internal static T Instantiate<T>(this MonoBehaviour self, T prefab, Vector3 position, Transform parent = null, Quaternion rotation = default) where T : UnityEngine.Object
        {
            var rot = rotation == default ? Quaternion.identity : rotation;
            var obj = parent == null ? UnityEngine.Object.Instantiate(prefab, position, rot) : UnityEngine.Object.Instantiate(prefab, parent);
            return obj;
        }

    }
}

