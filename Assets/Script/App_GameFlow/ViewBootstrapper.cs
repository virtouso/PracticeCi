using MVC.Script.MVC;
using Zenject;

namespace App.Script.App_GameFlow
{
    public interface IViewBootstrapper
    {
    }

    public class ViewBootstrapper : BaseView, IViewBootstrapper
    {
        [Inject] private DiContainer _container;
        private void Start()
        {


        }
    }
}