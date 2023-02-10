using System;
using System.Collections.Generic;
using App.Script.App_GameFlow.ScriptableObject;
using App.Script.App_GameFlow.View.GameScene.Game;
using Help.Script.Help.Extensions;
using Shared.Basic.DTO.Game.Response;
using Shared.Basic.DTO.Game.Signal;
using Shared.Basic.Enums;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Panel.Types
{
    public class GamePanelView : BasePanelView
    {
        private void AddGameView(BaseGameView gameView)
        {
            var result = _diContainer.InstantiatePrefabForComponent<BaseGameView>(gameView, _gameParent);
            result.transform.GetChild(0).gameObject.SetActive(false);
            _gameViews.Add(result.GameName, result);
        }

        private void OpenGame(GamePlayNames gamePlayName)
        {
            CloseAllGames();
            _gameViews[gamePlayName].Show();
        }


        private void CloseAllGames()
        {
            foreach (var item in _gameViews)
            {
                item.Value.Hide();
            }
        }

        [SerializeField] private Transform _gameParent;
        [Inject] private DiContainer _diContainer;
        [Inject] private SignalBus _signalBus;
        private readonly Dictionary<GamePlayNames, BaseGameView> _gameViews = new Dictionary<GamePlayNames, BaseGameView>();
        [Inject] private IUiReference _uiReference;


        private void Start()
        {
            _signalBus.Subscribe<RoundStartResponseSignal>(StartRound);

            foreach (var item in _uiReference.GameViews)
            {
                AddGameView(item.Value);
            }
        }

        private void StartRound(RoundStartResponseSignal obj)
        {
            OpenGame(obj.Data.GameName);
        }
    }
}