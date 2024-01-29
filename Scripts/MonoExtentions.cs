using System;
using System.Collections;
using UnityEngine;

namespace CodeHelper.Unity
{
    public static class MonoExtentions
    {

        /// <summary>Starts local coroutine, wait given time and invoke action </summary>
        /// <param name="time">Delay</param>
        public static void WaitAndDo(this MonoBehaviour self, float delay, Action toDo)
        {
            self.StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(delay);
                toDo.Invoke();
            }
        }
        
        public static T Instantiate<T>(this MonoBehaviour self, T prefab, Vector3 position, Transform parent = null, Quaternion rotation = default) where T : UnityEngine.Object
        {
            var rot = rotation == default ? Quaternion.identity : rotation;
            var obj = parent == null ? UnityEngine.Object.Instantiate(prefab, position, rot) : UnityEngine.Object.Instantiate(prefab, parent);
            return obj;
        }

        private static void SetParams<T>(ref GameObject obj, Vector3 pos, Quaternion rot)
        {
            obj.SetPosition(pos);
            obj.transform.rotation = rot;
        }
    }
}

