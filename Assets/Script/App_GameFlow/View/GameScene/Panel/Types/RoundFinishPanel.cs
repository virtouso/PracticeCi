using System;
using RTLTMPro;
using Shared.Basic.DTO.Game.Signal;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class RoundFinishPanel: BasePanelView
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ILogger _logger;

        [SerializeField] private RTLTextMeshPro _resultsText;
        
        private void Start()
        {
            _signalBus.Subscribe<RoundFinishResponseSignal>(ShowRoundFinishResults);
        }

        private void ShowRoundFinishResults(RoundFinishResponseSignal obj)
        {
          _logger.ShowErrorLog("show round start message", Color.magenta, Channels.GameFlow);
          string resultText = "";

          foreach (var item in  obj.Data.PlayersRoundScores)
          {
              resultText += $"{item.Key}:{item.Value}{Environment.NewLine}";
          }

          _resultsText.text = resultText;
          
        }
    }
}