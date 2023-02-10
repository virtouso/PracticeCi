using System;
using App.Script.App_GameFlow.Controller;
using MVC.Script.MVC;
using Shared.Basic.DTO.Game.Signal;
using Shared.Basic.Enums;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Game
{
    public abstract class BaseGameView : BaseView
    {
        public GamePlayNames GameName;

        [Inject] private SignalBus _signalBus;
        [Inject] protected IGamePlayController GamePlayController;

        public virtual void Show()
        {
            transform.GetChild(0).gameObject.SetActive(true);
            _signalBus.Subscribe<GameQuestionResponseSignal>(ShowQuestion);
            _signalBus.Subscribe<GameAnswerResponseSignal>(ShowAnswer);
            _signalBus.Subscribe<RoundStartResponseSignal>(ShowStart);
        }

        public virtual void Hide()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            _signalBus.TryUnsubscribe<GameQuestionResponseSignal>(ShowQuestion);
            _signalBus.TryUnsubscribe<GameAnswerResponseSignal>(ShowAnswer);
            _signalBus.TryUnsubscribe<RoundStartResponseSignal>(ShowStart);

        }

        protected abstract void ShowQuestion(GameQuestionResponseSignal signal);
        protected abstract void ShowAnswer(GameAnswerResponseSignal signal);
        protected abstract void ShowStart(RoundStartResponseSignal signal);

    }
}