using MVC.Script.MVC;

namespace App.Script.App_GameFlow.View.GameScene.Dialog
{
    public abstract class BaseDialogView : BaseView
    {
        public DialogName DialogName;
        
        public void Show()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Hide()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        
    }

    public enum DialogName
    {
        Settings
    }
}