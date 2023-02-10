using UnityEngine;

namespace Help.Script.Help.SceneManager.AssetLoaderScene.Panels
{
    public abstract class BaseAssetLoaderPanel: MonoBehaviour
    {
        public PanelId PanelId;
    }


    public enum PanelId
    {
        Validation,
        Login,
        SignUp,
        Message
    }
    
}