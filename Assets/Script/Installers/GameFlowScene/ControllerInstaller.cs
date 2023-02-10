using App.Script.App_GameFlow.Controller;
using Zenject;

namespace Script.Installers.GameFlowScene
{
    public class ControllerInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IServiceController>().To<ServiceController>().FromNew().AsSingle();
            Container.Bind<IDataController>().To<DataController>().FromNew().AsSingle();
            Container.Bind<IStateController>().To<StateController>().FromNew().AsSingle();
            Container.Bind<IUiController>().To<UiController>().FromNew().AsSingle();
            Container.Bind<IGamePlayController>().To<GamePlayController>().FromNew().AsSingle();
        }
    }
}