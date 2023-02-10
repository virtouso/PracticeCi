using System;
using System.Collections.Generic;

namespace App.Script.App_GameFlow.View.GameScene.Message.Types
{
    public class MultiChoiceMessageView: BaseMessageView
    {
        public override void Show(string title, string body, Action openAction = null, Action closeAction = null, int keepAliveSeconds = -1, Dictionary<string, Action> options = null)
        {
            throw new NotImplementedException();
        }

        public override void Hide(Action action)
        {
            throw new NotImplementedException();
        }
    }
}