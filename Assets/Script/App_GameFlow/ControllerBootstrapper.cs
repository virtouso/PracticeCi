using App.Script.App_GameFlow.Controller;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow
{
    public interface IControllerBootstrapper
    {
    }

    public class ControllerBootstrapper : MonoBehaviour, IControllerBootstrapper
    {

        [Inject] [SerializeReference] private IDataController _dataController;
        [Inject] [SerializeReference] private IServiceController _serviceController;
        [Inject] [SerializeReference] private IStateController _stateController;
        [Inject] [SerializeReference] private IUiController _uiController;
        [Inject] [SerializeReference] private IGamePlayController _gamePlayController;
    }
}