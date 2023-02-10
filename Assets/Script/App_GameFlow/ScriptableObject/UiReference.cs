using System.Collections.Generic;
using App.Script.App_GameFlow.View.GameScene.Dialog;
using App.Script.App_GameFlow.View.GameScene.Game;
using App.Script.App_GameFlow.View.GameScene.Message;
using App.Script.App_GameFlow.View.GameScene.Panel;
using Shared.Basic.Enums;
using UnityEngine;

namespace App.Script.App_GameFlow.ScriptableObject
{
    public interface IUiReference
    {
        Dictionary<PanelName, BasePanelView> Panels { get; }
        Dictionary<DialogName, BaseDialogView> Dialogs { get; }
        Dictionary<MessageName, BaseMessageView> Messages { get; }
        Dictionary<GamePlayNames, BaseGameView> GameViews { get; }
    }

    public class UiReference : UnityEngine.ScriptableObject, IUiReference
    {
        [SerializeField] private List<BasePanelView> _panelsList;
        public Dictionary<PanelName, BasePanelView> Panels { get; } = new Dictionary<PanelName, BasePanelView>();

        [SerializeField] private List<BaseDialogView> _dialogsList;
        public Dictionary<DialogName, BaseDialogView> Dialogs { get; } = new Dictionary<DialogName, BaseDialogView>();

        [SerializeField] private List<BaseMessageView> _messagesList;
        public Dictionary<MessageName, BaseMessageView> Messages { get; } = new Dictionary<MessageName, BaseMessageView>();

        [SerializeField] private List<BaseGameView> _gameViews;
        public Dictionary<GamePlayNames, BaseGameView> GameViews { get; } = new Dictionary<GamePlayNames, BaseGameView>();


        public void Init()
        {
            _panelsList.ForEach(x => Panels.Add(x.PanelName, x));
            _dialogsList.ForEach(x => Dialogs.Add(x.DialogName, x));
            _messagesList.ForEach(x => Messages.Add(x.MessageName, x));
            _gameViews.ForEach(x => GameViews.Add(x.GameName, x));
        }
    }
}