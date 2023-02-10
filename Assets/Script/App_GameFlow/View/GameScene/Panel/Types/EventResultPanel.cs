using System;
using RTLTMPro;
using Shared.Basic.DTO.Game.Signal;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class EventResultPanel: BasePanelView
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private RTLTextMeshPro _rankingText;


        private void Start()
        {
            _signalBus.Subscribe<EventFinishResponseSignal>(ShowResult);
        }

        private void ShowResult()
        {
            throw new NotImplementedException();
        }
    }
}