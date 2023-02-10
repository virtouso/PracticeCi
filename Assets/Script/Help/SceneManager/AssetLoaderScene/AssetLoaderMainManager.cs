using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Help.Script.Help.SceneManager.AssetLoaderScene
{
    public class AssetLoaderMainManager: MonoBehaviour
    {
        [Inject]   private SignalBus _signalBus;
      
        private async void StartSceneDelayed()
        {
            await UniTask.DelayFrame(1);
         //   _signalBus.Fire<SceneStartSignal>(new SceneStartSignal());
        }
        
        private void Start()
        {
            StartSceneDelayed();
        }
    }
}