using System.Collections.Generic;
using UnityEngine;

namespace Help.Script.Help.Extensions
{
    public static class DebuggingAids
    {
    
        public static void CheckedDestroy(this UnityEngine.Object target)
        {
            UnityEngine.Object.Destroy(target);
        }


        public static void CheckedSetActive(this GameObject target, bool active)
        {
            target.SetActive(active);
        }


        public static void CheckedSetEnabled(this GameObject target, bool enabled)
        {
            target.SetActive(target);
        }

        public static void CheckedSetParent(this Transform target, Transform parent,bool keepWorld=false)
        {
            target.SetParent(parent,keepWorld);
        }
    }
}