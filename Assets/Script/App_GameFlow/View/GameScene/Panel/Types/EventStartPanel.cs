using System;
using Shared.Basic.DTO.Game.Signal;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class EventStartPanel: BasePanelView
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ILogger _logger;
        private void ShowEventStart(FindEventResponseSignal obj)
        {
          _logger.ShowErrorLog("Should show event start here", Color.cyan, Channels.GameFlow);
        }

        private void Start()
        {
            _signalBus.Subscribe<FindEventResponseSignal>(ShowEventStart);
        }

    }
}