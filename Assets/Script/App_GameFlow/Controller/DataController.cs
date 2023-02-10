using System.Collections.Generic;
using App.Script.App_GameFlow.Model;
using Help.Script.Help.MultiLanguageSystem.Models;
using MVC.Script.MVC;
using Shared.Basic.DTO.Game.Signal;
using Shared.Basic.GameEntities;
using Shared.Basic.Models;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.Controller
{
    public interface IDataController
    {
        Language GetActiveLanguage();
        (string id, string email) GetUserIdentity();

        public Dictionary<ProgressType, int> GetPlayerProgress();
        public Dictionary<GameCurrency, int> GetPlayerResources();

        public PlayerStats GetUserStats();
        
        
    }

    public class DataController : BaseController, IDataController
    {
        [Inject] [SerializeField] private PlayerDataModel _playerDataModel;

        public Language GetActiveLanguage()
        {
            return _playerDataModel.Langauge;
        }

        public (string id, string email) GetUserIdentity()
        {
            return (_playerDataModel.PlayerData.UserId, _playerDataModel.PlayerData.Email);
        }

        public Dictionary<ProgressType, int> GetPlayerProgress()
        {
            return _playerDataModel.PlayerData.PlayerProgress;
        }

        public Dictionary<GameCurrency, int> GetPlayerResources()
        {
            return _playerDataModel.PlayerData.OwnedResources;
        }

        public PlayerStats GetUserStats()
        {
            return _playerDataModel.PlayerData.Stats;
        }

        private SignalBus _signalBus;
        public DataController(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<FindEventResponseSignal>(signal => _playerDataModel.GameToken= signal.Data.GameplayToken);
        }
    }
}