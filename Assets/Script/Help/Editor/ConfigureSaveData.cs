#if UNITY_EDITOR

using UnityEditor;

namespace Help.Script.Help.Editor
{
    public class ConfigureSaveData : EditorWindow
    {
      //   private static ConfigureSaveData window;
      //
      // //  private PlayerData _data;
      //   private IUtilitySerializer _serializer;
      //   private IUtilityFile _utilityFile;
      //
      //   [MenuItem("Extension/ Progress")]
      //   public static void CreateProgressEditorWindow()
      //   {
      //       window = GetWindow<ConfigureSaveData>(false, "Game Progress Editor");
      //   }
      //
      //   public ConfigureSaveData()
      //   {
      //   }
      //
      //
      //   private void OnEnable()
      //   {
      //       _serializer = new UtilityNewtonSoftJson();
      //       _utilityFile = new UtilitySimplePLayerPrefs();
      //
      //       if (!_utilityFile.KeyExist(FileSaveKeys.PlayerData))
      //       {
      //           _data = new PlayerData();
      //       }
      //       else
      //       {
      //           string stringData = _utilityFile.LoadString(FileSaveKeys.PlayerData);
      //           _data = _serializer.Deserialize<PlayerData>(stringData);
      //       }
      //   }
      //
      //
      //   private void OnGUI()
      //   {
      //     //   for (int i = 0; i < _data.OwnedElements.Count; i++)
      //     //   {
      //     //       EditorGUILayout.LabelField(_data.OwnedElements.ElementAt(i).Key.ToString());
      //     //       var data = _data.OwnedElements.ElementAt(i);
      //     // //  data.Value = EditorGUILayout.IntField("input",_data.OwnedElements.ElementAt(i).Value);
      //     //     //      var item=   _data.OwnedElements.ElementAt(i);
      //     // //    item = new KeyValuePair<GameElementNames, int>(item.Key,item.Value);
      //     //   }
      //
      //
      //       if (GUILayout.Button("Save Player Data"))
      //       {
      //           string serialized = _serializer.Serialize(_data);
      //           _utilityFile.SaveString(FileSaveKeys.PlayerData, serialized);
      //       }
      //   }
    }
}


#endif