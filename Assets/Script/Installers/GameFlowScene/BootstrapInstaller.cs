using App.Script.App_GameFlow;
using Zenject;

namespace Script.Installers.GameFlowScene
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IViewBootstrapper>().To<ViewBootstrapper>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<IModelBootstrapper>().To<ModelBootstrapper>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<IControllerBootstrapper>().To<ControllerBootstrapper>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}