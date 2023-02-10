using System;
using System.Collections.Generic;
using App.Script.App_GameFlow.Controller;
using Cysharp.Threading.Tasks;
using Help.Script.Help.MultiLanguageSystem.ScriptableObject;
using RTLTMPro;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Message.Types
{
    public class ToastView : BaseMessageView
    {
        [SerializeField] private RTLTextMeshPro _messageText;

        [Inject] private IMultiLanguageReference _languageReference;
        [Inject] private IDataController _dataController;
        
        private Action _closeAction;
        
        public override async void Show(string titleGuid, string bodyGuid, Action openAction = null, Action closeAction = null, int keepAliveSeconds = -1, Dictionary<string, Action> options = null)
        {
            transform.GetChild(0).gameObject.SetActive(true);

            var language = _dataController.GetActiveLanguage();
            _messageText.UpdateValue(_languageReference.GetText(bodyGuid,language));
            openAction?.Invoke();

            if (keepAliveSeconds < 0) return;

            await UniTask.Delay(keepAliveSeconds * 1000);
            transform.GetChild(0).gameObject.SetActive(false);
            
        }

        public override void Hide(Action action)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            _closeAction?.Invoke();
        }
    }
}