using System;
using Shared.Basic.DTO.Game.Signal;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class GameSelectionPanelView: BasePanelView
    {

        [Inject] private SignalBus _signalBus;
        [Inject] private ILogger _logger;
        
        
        private void Start()
        {
            _signalBus.Subscribe<GameTypeSelectionStartResponseSignal>(OnServerGameSelected);
            _signalBus.Subscribe<GameTypeSelectionStartResponseSignal>(OnStartSignal);
        }

        private void OnStartSignal(GameTypeSelectionStartResponseSignal obj)
        {
            _logger.ShowErrorLog("game selection opened. show stuff",Color.magenta, Channels.GameFlow );
        }

        private void OnServerGameSelected(GameTypeSelectionStartResponseSignal obj)
        {
            _logger.ShowErrorLog("Show Selected Game Here", Color.blue, Channels.GameFlow);
        }
    }
}