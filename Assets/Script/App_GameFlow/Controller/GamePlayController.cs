using App.Script.App_GameFlow.Service.Match;
using App.Script.App_GameFlow.Service.Match.Types;
using App.Script.App_GameFlow.View.GameScene.Panel;
using MVC.Script.MVC;
using Shared.Basic.DTO.Game.Request;
using Shared.Basic.DTO.Game.Response;
using Shared.Basic.DTO.Game.Signal;
using Shared.Basic.Enums;
using Zenject;

namespace App.Script.App_GameFlow.Controller
{
    public interface IGamePlayController
    {
        void RequestSingleMatchEvent(MatchTypes matchType);
        void RequestGameAnswer(GameAnswerRequest request);
        void RequestGamePlayType(GamePlayTypeRequest request);
    }

    public class GamePlayController : BaseController, IGamePlayController
    {
        private BaseEventService _eventService = null;

        public void RequestSingleMatchEvent(MatchTypes matchType)
        {
            _uiController.ShowPanel(PanelName.Lobby);

            if (matchType == MatchTypes.Offline)
                _eventService = new OfflineEventService();
            else
                _eventService = new OnlineEventService();

            _container.Inject(_eventService);

            _eventService.OnError = response => { _signalBus.Fire<ErrorResponseSignal>(new ErrorResponseSignal(response));};
            _eventService.OnEventFound = response => { _signalBus.Fire<FindEventResponseSignal>(new FindEventResponseSignal(response));};
            _eventService.OnMatchFinish = response => { _signalBus.Fire<MatchFinishResponseSignal>(new MatchFinishResponseSignal(response));};
            _eventService.OnMatchStart = response => {_signalBus.Fire<MatchStartResponseSignal>(new MatchStartResponseSignal(response)); };
            _eventService.OnRoundFinish = response => {_signalBus.Fire<RoundFinishResponseSignal>(new RoundFinishResponseSignal(response)); };
            _eventService.OnRoundStarted = response => { _signalBus.Fire<RoundStartResponseSignal>(new RoundStartResponseSignal(response));};
            _eventService.OnGameAnswerResponse = response => {_signalBus.Fire<GameAnswerResponseSignal>(new GameAnswerResponseSignal(response)); };
            _eventService.OnGameQuestionResponse = response => { _signalBus.Fire<GameQuestionResponseSignal>(new GameQuestionResponseSignal(response));};
            _eventService.OnGameTypeSelectionStarted = response => {_signalBus.Fire<GameTypeSelectionStartResponseSignal>(new GameTypeSelectionStartResponseSignal(response)); };

            _eventService.RequestEvent(new FindEventRequest(EventTypes.SingleMatch,_dataController.GetUserIdentity().id));
        }

        public void RequestGameAnswer(GameAnswerRequest request)
        {
            _eventService.RequestGameAnswer(request);
        }

        public void RequestGamePlayType(GamePlayTypeRequest request)
        {
            _eventService.RequestGamePlayType(request);
        }


        private readonly DiContainer _container;
        private readonly IUiController _uiController;
        private readonly SignalBus _signalBus;
        private readonly IDataController _dataController;
        public GamePlayController(IUiController uiController, SignalBus signalBus,IDataController dataController, DiContainer container)
        {
            _uiController = uiController;
            _signalBus = signalBus;
            _container = container;
            _dataController = dataController;
        }
    }
}