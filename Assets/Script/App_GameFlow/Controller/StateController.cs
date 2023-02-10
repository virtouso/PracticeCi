using App.Script.App_GameFlow.View.GameScene.Panel;
using MVC.Script.MVC;
using Zenject;

namespace App.Script.App_GameFlow.Controller
{
    public interface IStateController{}
    public class StateController: BaseController, IStateController
    {

        private IUiController _uiController;


        public StateController(IUiController uiController)
        {
            _uiController = uiController;
            
            _uiController.ShowPanel(PanelName.Landing);
        }
    }
}