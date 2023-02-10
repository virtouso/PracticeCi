using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Script.App_GameFlow.Controller;
using GameLogics.GamePlay;
using GameLogics.GlobalGameEntities;
using Help.Script.Help.ScriptableObjects;
using Shared.Basic.Consts.Settings;
using Shared.Basic.DTO.Game.Request;
using Shared.Basic.DTO.Game.Response;
using Shared.Basic.Enums;
using Shared.Basic.Models;
using Zenject;


namespace App.Script.App_GameFlow.Service.Match.Types
{
    public class OfflineEventService : BaseEventService
    {
        [Inject] private IDataController _dataController;
        [Inject] private LocalPlayersConfiguration _localPlayersConfiguration;


        private IGameMatch match;

        public override async void RequestEvent(FindEventRequest request)
        {
            match = new GameMatch(request.EventType, "");
            //  IMatch match = new Match();

            var randomPlayer = _localPlayersConfiguration.GetRandomPlayer();

            match.AddPlayer(new MatchPlayer(request.UserId, "", "", EventTypes.SingleMatch, _dataController.GetPlayerResources(), _dataController.GetPlayerProgress()));
            match.AddPlayer(new MatchPlayer(randomPlayer.PlayerId, "", "", EventTypes.SingleMatch, null, null));

            //OnEventFound.Invoke(new FindEventResponse("ddddd", EventTypes.SingleMatch, match.Players.ToDictionary(x => x.Key, y => y.Key)));
            match.RequestUpdateMatchState(MatchState.Prepare);
            await Task.Delay(3000);

            OnMatchStart.Invoke(new MatchStartResponse(new Dictionary<string, PlayerStats> { { _dataController.GetUserIdentity().id, _dataController.GetUserStats() }, { randomPlayer.PlayerId, randomPlayer.Stats } }));

            await Task.Delay(3000);

            for (int i = 0; i < GeneralGameSettings.MaxRoundsNumber; i++)
            {
                OnGameTypeSelectionStarted.Invoke(new GameTypeSelectionStartResponse(match.GetPlayedGames()));
                await Task.Delay(GeneralGameSettings.MatchGamePlaySelectionTime * 1000);
                //    var newMatch = GamePlayCaching.GetFirstUnPlayed(match.GetPlayedGames());
                var newMatch = GamePlayCaching.GetGamePlay(GamePlayNames.NearestNumber);
                match.Rounds.Add(new Round(i, newMatch, match.Players));
                OnRoundStarted.Invoke(new RoundStartResponse(newMatch.GamePlayName));
                OnGameQuestionResponse.Invoke(new GameQuestionResponse(match.CurrentRound.Game.GetStepQuestion(0)));
                await Task.Delay(15 * 1000);
                OnRoundFinish.Invoke(new RoundFinishResponse(match.CurrentRound.RoundPlayers.ToDictionary(x => x.Key, y => y.Value.score)));
                await Task.Delay(2000);
            }

            OnMatchFinish.Invoke(new MatchFinishResponse(match.GetMatchScores()));
        }

        public override void RequestGamePlayType(GamePlayTypeRequest request)
        {
            throw new System.NotImplementedException();
        }

        public override async void RequestGameAnswer(GameAnswerRequest request)
        {
            var result = match.CurrentRound.ApplyPlay(request.Answer, request.UserId);
            OnGameAnswerResponse.Invoke(new GameAnswerResponse(result.rightAnswer));
            await Task.Delay(200);
            if (result.responseType == PlayResponseType.Normal)
                OnGameQuestionResponse.Invoke(new GameQuestionResponse(result.nextQuestion));
        }
    }
}