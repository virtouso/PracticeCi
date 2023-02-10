using UnityEngine;
using Zenject;

namespace Script.Installers.GameFlowScene
{
    public class UtilityInstaller : MonoInstaller
    {
        [SerializeField] private LoggerChannels _channels;
        public override void InstallBindings()
        {
            Container.Bind<ILogger>().To<Logger>().FromInstance(new Logger(_channels)).AsSingle();
        }
    }
}
