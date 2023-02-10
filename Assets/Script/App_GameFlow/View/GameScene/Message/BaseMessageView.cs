using System;
using System.Collections.Generic;
using MVC.Script.MVC;

namespace App.Script.App_GameFlow.View.GameScene.Message
{
    public abstract class BaseMessageView: BaseView
    {
        public MessageName MessageName;
        
        public abstract void Show(string title, string body,Action openAction=null, Action closeAction=null, int keepAliveSeconds=-1, Dictionary<string,Action> options= null);

        public abstract void Hide(Action action=null);
    }



    public enum MessageName
    {
        Toast,
        MultiChoice
    }
    
    
}