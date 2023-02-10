using System;
using App.Script.App_GameFlow.Controller;
using Shared.Basic.Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class LandingPanelView: BasePanelView
    {
        [Inject] private readonly IGamePlayController _gamePlayController;
        [SerializeField] public Button _singleMatchRequestPlayButton;


        private void RequestSingleMatchEvent()
        {
            _gamePlayController.RequestSingleMatchEvent(MatchTypes.Offline);
        }
        
        private void Start()
        {
            _singleMatchRequestPlayButton.onClick.AddListener(RequestSingleMatchEvent);
        }
    }
}