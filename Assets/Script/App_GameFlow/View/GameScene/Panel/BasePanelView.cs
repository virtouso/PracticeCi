using MVC.Script.MVC;

namespace App.Script.App_GameFlow.View.GameScene.Panel
{
    public abstract class BasePanelView : BaseView
    {
        public PanelName PanelName;


        public virtual void Show()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Hide()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        
        
    }


    public enum PanelName
    {
        GamePlay,
        GameSelection,
        Landing,
        Lobby,
        MatchResult,
        MatchStart,
        EventResult,
        EventStart,
        RoundFinish
    }
}