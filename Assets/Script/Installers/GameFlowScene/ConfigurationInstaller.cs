using App.Script.App_GameFlow.ScriptableObject;
using Help.Script.Help.ScriptableObjects;
using UnityEngine;
using Zenject;


namespace Script.Installers.GameFlowScene
{
    public class ConfigurationInstaller : MonoInstaller
    {
        [SerializeField] private GeneralGameSettings _generalGameSettings;
        [SerializeField] private UiReference _uiReference;

        [SerializeField] private AvatarsConfiguration _avatarsConfiguration;
        [SerializeField] private BackendConfiguration _backendConfiguration;
        [SerializeField] private LocalGames _localGames;
        [SerializeField] private LocalPlayersConfiguration _localPlayersConfiguration;
        
        public override void InstallBindings()
        {
            Container.Bind<GeneralGameSettings>().FromScriptableObject(_generalGameSettings).AsSingle();
            Container.Bind<IUiReference>().To<UiReference>().FromScriptableObject(_uiReference).AsSingle();

            Container.Bind<AvatarsConfiguration>().FromScriptableObject(_avatarsConfiguration).AsSingle();
            Container.Bind<IBackendConfiguration>().To<BackendConfiguration>().FromScriptableObject(_backendConfiguration).AsSingle();
            Container.Bind<LocalGames>().FromScriptableObject(_localGames).AsSingle();
            Container.Bind<LocalPlayersConfiguration>().FromScriptableObject(_localPlayersConfiguration).AsSingle();
        
            
            _uiReference.Init();
        }
    }
}