#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

namespace Help.Script.Help.Editor
{
    public static class ScriptableObjectAssetCreator
    {
        [MenuItem("Extension/Create ScriptableObject")]
        public static void Create()
        {
            var script = Selection.activeObject as MonoScript;
            var type = script.GetClass();
            var scriptableObject = ScriptableObject.CreateInstance(type);
            var path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(script));
            AssetDatabase.CreateAsset(scriptableObject, $"{path}/{Selection.activeObject.name}.asset");
        }

        [MenuItem("Assets/Create ScriptableObject", true)]
        public static bool ValidateCreate()
        {
            var script = Selection.activeObject as MonoScript;
            return script != null && script.GetClass().IsSubclassOf(typeof(ScriptableObject));
        }
    }
}

#endif