using Shared.Basic.DTO.Game.Signal;
using Zenject;

namespace Script.Installers.GameFlowScene
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<ErrorResponseSignal>();
            Container.DeclareSignal<EventFinishResponseSignal>();
            Container.DeclareSignal<FindEventResponseSignal>();
            Container.DeclareSignal<GameAnswerResponseSignal>();
            Container.DeclareSignal<GamePlayTypeSelectionResponseSignal>();
            Container.DeclareSignal<GameQuestionResponseSignal>();
            Container.DeclareSignal<GameTypeSelectionStartResponseSignal>();
            Container.DeclareSignal<MatchFinishResponseSignal>();
            Container.DeclareSignal<MatchStartResponseSignal>();
            Container.DeclareSignal<RoundFinishResponseSignal>();
            Container.DeclareSignal<RoundStartResponseSignal>();
        }
    }
}