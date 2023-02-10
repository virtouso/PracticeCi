using System.Collections.Generic;
using System.Linq;
using Help.Script.Help.Consts.Keys;
using Help.Script.Help.SceneManager.AssetLoaderScene.Panels;
using Help.Script.Help.ScriptableObjects;
using UnityEngine;
using Zenject;

//using OceanExplorer.Managers;

namespace Help.Script.Help.SceneManager.AssetLoaderScene
{
    public class AssetLoaderServicesManager : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        //   [Inject] private IDataManager _dataManager;
        //  [Inject] private IBackendServicesManager _backendServicesManager;
        [Inject] private IBackendConfiguration _backendConfiguration;
        [SerializeField] private List<BaseAssetLoaderPanel> _panels;

        [SerializeField] private MessagePanel _messagePanel;

        private void OpenPanel(PanelId panel)
        {
            foreach (var item in _panels)
            {
                item.transform.GetChild(0).gameObject.SetActive(false);
            }

            _panels.First(x => x.PanelId == panel).transform.GetChild(0).gameObject.SetActive(true);
        }

        private void ShowMessage(string message)
        {
            _messagePanel.Show(message);
        }

        private void StartAuthProcess()
        {
       
            //  if (_dataManager.PlayerData.UserAuthenticationInstance.HasLoggedIn)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(SceneNames.GameFlow);
            }
            //   else
            {
                OpenPanel(PanelId.SignUp);
            }
        }

        private void Start()
        {
            //  _signalBus.Subscribe<PlayerDataResolvedSignal>(signal => StartAuthProcess());
          //  _signalBus.Subscribe<OpenPanelSignal>(signal => OpenPanel(signal.Id));
         //   _signalBus.Subscribe<ShowMessagePanelSignal>(signal => ShowMessage(signal.Message));
        }
    }
}