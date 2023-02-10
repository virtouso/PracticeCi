using App.Script.App_GameFlow.Model;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow
{
    
    public interface  IModelBootstrapper{}
    
    public class ModelBootstrapper : MonoBehaviour, IModelBootstrapper
    {
        [Inject][SerializeField] private StateModel _stateModel;
        [Inject] [SerializeField] private PlayerDataModel _playerDataModel;

    }
}
