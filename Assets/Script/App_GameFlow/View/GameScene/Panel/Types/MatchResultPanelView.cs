using System;
using App.Script.App_GameFlow.Controller;
using RTLTMPro;
using Shared.Basic.DTO.Game.Signal;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class MatchResultPanelView : BasePanelView
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ILogger _logger;
        [Inject] private IUiController _uiController;
        
        [SerializeField] private Button _returnButton;
        [SerializeField] private RTLTextMeshPro _resultsText;

        private void ReturnButtonPressed()
        {
            _uiController.ShowPanel(PanelName.Landing);
        }
        
        
        private void ShowMatchResults(MatchFinishResponseSignal obj)
        {
            _logger.ShowErrorLog("show match result here", Color.blue, Channels.GameFlow);

            string resultText = "";

            foreach (var item in  obj.Data.PlayersScores)
            {
                resultText += $"{item.Key}:{item.Value}{Environment.NewLine}";
            }

            _resultsText.text = resultText;
        }
        
        private void Start()
        {
            _signalBus.Subscribe<MatchFinishResponseSignal>(ShowMatchResults);
            
            _returnButton.onClick.AddListener(ReturnButtonPressed);
        }

  
    }
}