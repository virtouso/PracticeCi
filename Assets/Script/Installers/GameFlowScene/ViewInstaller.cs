using Help.Script.Help.Consts.Identifiers;
using UnityEngine;
using Zenject;

//using BoxCollectorExample.Script.View;

namespace Script.Installers.GameFlowScene
{
    public class ViewInstaller: MonoInstaller
    {
        
      [SerializeField] private Canvas _panelCanvas;
      [SerializeField] private Canvas _dialogCanvas;
      [SerializeField] private Canvas _messageCanvas;
      
        public override void InstallBindings()
        {
            Container.Bind<Canvas>().WithId(CanvasIds.Panel).FromInstance(_panelCanvas).AsCached();
            Container.Bind<Canvas>().WithId(CanvasIds.Dialog).FromInstance(_dialogCanvas).AsCached();
            Container.Bind<Canvas>().WithId(CanvasIds.Message).FromInstance(_messageCanvas).AsCached();
        }
    }
}