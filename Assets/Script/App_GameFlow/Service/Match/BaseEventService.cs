using System;

using MVC.Script.MVC;
using Shared.Basic.DTO.Game.Request;
using Shared.Basic.DTO.Game.Response;

namespace App.Script.App_GameFlow.Service.Match
{
    public abstract class BaseEventService : BaseService
    {
        // request

        public abstract void RequestEvent(FindEventRequest request);
        public abstract void RequestGamePlayType(GamePlayTypeRequest request);
        public abstract void RequestGameAnswer(GameAnswerRequest request);

        // callbacks

        public Action<ErrorResponse> OnError { get; set; }
        public Action<FindEventResponse> OnEventFound { get; set; }
        public Action<MatchStartResponse> OnMatchStart { get; set; }
        public Action<MatchFinishResponse> OnMatchFinish { get; set; }
        public Action<GameAnswerResponse> OnGameAnswerResponse { get; set; }
        public Action<GameQuestionResponse> OnGameQuestionResponse { get; set; }
        public Action<GamePlayTypeSelectionResponse> OnGamePlaySelectionResponse { get; set; }
        
        public Action<GameTypeSelectionStartResponse> OnGameTypeSelectionStarted { get; set; }
        public Action<RoundStartResponse> OnRoundStarted { get; set; }

        public Action<RoundFinishResponse> OnRoundFinish { get; set; }
    }
}