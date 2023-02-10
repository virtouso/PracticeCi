using UnityEngine;
using Zenject;

namespace MVC.Script.MVC
{
    public abstract class BaseView : MonoBehaviour

    {
        [Inject] private SignalBus _signalBus;


        public void SetParent(Transform parent = null,bool keepWorld=false)
        {
            if (parent == null) return;
            transform.SetParent(parent,keepWorld);
        }
    }
}