using EasyButtons;
using UnityEditor;
using UnityEngine;

namespace Help.Script.Help.Editor
{
    public class ModelMaterialSetter : MonoBehaviour
    {
        [SerializeField] private Material _material;

        [Button]
        private void SetMaterialToChildren()
        {
            var allChildren = GetComponentsInChildren<MeshRenderer>();


            foreach (var mesh in allChildren)
            {
                mesh.material = _material;
            }
#if UNITY_EDITOR
            if (Application.isEditor && !Application.isPlaying)
            {
                EditorUtility.SetDirty(this);
                EditorApplication.MarkSceneDirty();
            }
#endif
        }
    }
}