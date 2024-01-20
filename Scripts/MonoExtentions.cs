using System;
using System.Collections;
using UnityEngine;

namespace CodeHelper.Unity
{
    public static class MonoExtentions
    {
        public static void WaitAndDo(this MonoBehaviour self, float time, Action toDo)
        {
            self.StartCoroutine(Waiter());
            IEnumerator Waiter()
            {
                yield return new WaitForSeconds(time);
                toDo.Invoke();
            }
        }
        
        public static GameObject Instantiate(this MonoBehaviour self, GameObject prefab, Vector3 position, Transform parent = null, Quaternion rotation = default) 
        {
            var rot = rotation == default ? Quaternion.identity : rotation;
            GameObject obj = GameObject.Instantiate(prefab,position,rot);
            if (parent != null) obj.transform.parent = parent;
            return obj;
        }
    }
}

