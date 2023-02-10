using App.Script.App_GameFlow.Model;
using Zenject;

namespace Script.Installers.GameFlowScene
{
    public class ModelInstaller:MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerDataModel>().FromNew().AsSingle();
            Container.Bind<StateModel>().FromNew().AsSingle();
        }
    }
}