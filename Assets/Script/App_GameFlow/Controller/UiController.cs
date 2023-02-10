using System.Collections.Generic;
using App.Script.App_GameFlow.ScriptableObject;
using App.Script.App_GameFlow.View.GameScene.Dialog;
using App.Script.App_GameFlow.View.GameScene.Message;
using App.Script.App_GameFlow.View.GameScene.Panel;
using Help.Script.Help.Consts.Identifiers;
using MVC.Script.MVC;
using Shared.Basic.DTO.Game.Signal;
using TMPro;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.Controller
{
    public interface IUiController
    {
        void ShowPanel(PanelName panelName);

        void ShowDialog(DialogName dialogName);


        void ShowToast(string message, int keepAlive = 1);
    }

    public class UiController : BaseController, IUiController
    {
        private Canvas _panelsCanvas;
        private Canvas _dialogsCanvas;
        private Canvas _messagesCanvas;

        private IUiReference _uiReference;
        private DiContainer _container;
        private SignalBus _signalBus;

        private Dictionary<PanelName, BasePanelView> _activePanels = new Dictionary<PanelName, BasePanelView>();
        private Dictionary<DialogName, BaseDialogView> _activeDialogs = new Dictionary<DialogName, BaseDialogView>();
        private Dictionary<MessageName, BaseMessageView> _activeMessages = new Dictionary<MessageName, BaseMessageView>();

        public void ShowPanel(PanelName panelName)
        {
            foreach (var item in _activePanels)
            {
                item.Value.Hide();
            }

            _activePanels[panelName].Show();
        }

        public void ShowDialog(DialogName dialogName)
        {
            _activeDialogs[dialogName].Show();
        }

        public void ShowToast(string message, int keepAlive = 1)
        {
            _activeMessages[MessageName.Toast].Show(null, message, null, null, keepAlive, null);
        }


        private void Init()
        {
            foreach (var item in _uiReference.Panels)
            {
                var result = _container.InstantiatePrefabForComponent<BasePanelView>(item.Value);
                result.Hide();
                result.SetParent(_panelsCanvas.transform);
                _activePanels.Add(result.PanelName, result);
            }

            foreach (var item in _uiReference.Dialogs)
            {
                var result = _container.InstantiatePrefabForComponent<BaseDialogView>(item.Value);
                result.Hide();
                result.SetParent(_dialogsCanvas.transform);
                _activeDialogs.Add(item.Key, result);
            }

            foreach (var item in _uiReference.Messages)
            {
                var result = _container.InstantiatePrefabForComponent<BaseMessageView>(item.Value);
                result.Hide();
                result.SetParent(_messagesCanvas.transform);
                _activeMessages.Add(item.Key, result);
            }
        }


        private void InitSignals()
        {
            _signalBus.Subscribe<ErrorResponseSignal>(signal => ShowToast(signal.Data.Message));
            _signalBus.Subscribe<EventFinishResponseSignal>(signal => ShowPanel(PanelName.EventResult));
            _signalBus.Subscribe<FindEventResponseSignal>(signal => ShowPanel(PanelName.EventStart));
            _signalBus.Subscribe<GameTypeSelectionStartResponseSignal>(signal => ShowPanel(PanelName.GameSelection));
            _signalBus.Subscribe<MatchFinishResponseSignal>(signal => ShowPanel(PanelName.MatchResult));
            _signalBus.Subscribe<MatchStartResponseSignal>(signal => ShowPanel(PanelName.MatchStart));
            _signalBus.Subscribe<RoundFinishResponseSignal>(signal =>ShowPanel(PanelName.RoundFinish) );
            _signalBus.Subscribe<RoundStartResponseSignal>(signal =>ShowPanel(PanelName.GamePlay) );
        }


        public UiController(DiContainer container, [Inject(Id = CanvasIds.Panel)] Canvas panelCanvas, [Inject(Id = CanvasIds.Dialog)] Canvas dialogCanvas, [Inject(Id = CanvasIds.Message)] Canvas messageCanvas)
        {
            _panelsCanvas = panelCanvas;
            _dialogsCanvas = dialogCanvas;
            _messagesCanvas = messageCanvas;

            _container = container;
        }

        [Inject]
        public void Init(IUiReference uiReference, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _uiReference = uiReference;
            Init();
            InitSignals();
        }
    }
}