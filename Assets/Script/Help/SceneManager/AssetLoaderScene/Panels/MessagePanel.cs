using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Help.Script.Help.SceneManager.AssetLoaderScene.Panels
{
    public class MessagePanel: BaseAssetLoaderPanel
    {

        [SerializeField] private RTLTextMeshPro _text;
        [SerializeField] private Button _closeButton;

        public void Show(string data)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            _text.text = data;
        }


        private void Close()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        private void Start()
        {
            _closeButton.onClick.AddListener(Close);
        }
    }
}