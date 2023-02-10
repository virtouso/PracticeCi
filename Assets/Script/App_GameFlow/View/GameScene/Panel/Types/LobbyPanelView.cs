using App.Script.App_GameFlow.Controller;
using RTLTMPro;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class LobbyPanelView : BasePanelView
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private IDataController _dataController;
        [SerializeField] private RTLTextMeshPro _playerIdText;

        [SerializeField] private RTLTextMeshPro _messageText;

        public override void Show()
        {
            base.Show();

            _messageText.text = $"یافتن رویداد برای {_dataController.GetUserIdentity().id}";
            _playerIdText.text = _dataController.GetUserIdentity().id;
        }
    }
}