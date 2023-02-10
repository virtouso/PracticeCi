using Help.Script.Help.Editor;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private NamespaceHint _nh;
        
        [Inject] private IViewBootstrapper _viewBootstrapper;
        [Inject] private IModelBootstrapper _modelBootstrapper;
        [Inject] private IControllerBootstrapper _controllerBootstrapper;
        
        private void Start()
        {
            
        }
    }
}
