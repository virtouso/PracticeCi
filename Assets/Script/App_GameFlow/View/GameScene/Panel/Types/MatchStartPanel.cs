using System;
using Shared.Basic.DTO.Game.Signal;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class MatchStartPanel: BasePanelView
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private ILogger _logger;

        private void Start()
        {
            _signalBus.Subscribe<MatchStartResponseSignal>(ShowMatchStartInfo);
        }

        private void ShowMatchStartInfo(MatchStartResponseSignal obj)
        {
            _logger.ShowErrorLog("Should Show match Start Data", Color.cyan,  Channels.UI);
        }
    }
}