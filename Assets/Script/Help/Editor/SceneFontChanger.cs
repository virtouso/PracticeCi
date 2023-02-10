using RTLTMPro;
using TMPro;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Help.Script.Help.Editor
{
    public class SceneFontChanger : EditorWindow
    {
        private static SceneFontChanger _window;

        [MenuItem("Extension/ Change Fonts")]
        public static void CreateFontChangerWindow()
        {
            _window = GetWindow<SceneFontChanger>(false, "Scene Fonts Changer");
        }

        private TMP_FontAsset _font;

        private void OnGUI()
        {
            var allTextMeshProAssets = Resources.FindObjectsOfTypeAll<RTLTextMeshPro>();

            _font = (TMP_FontAsset)EditorGUILayout.ObjectField("font", _font, typeof(TMP_FontAsset), true);
            if (GUILayout.Button("Change Fonts"))
            {
                foreach (var item in allTextMeshProAssets)
                {
                    item.font = _font;
                }
            }
        }
    }
}
#endif