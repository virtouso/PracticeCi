using Help.Script.Help.MultiLanguageSystem.ScriptableObject;
using RTLTMPro;
using UnityEngine;
using Zenject;

namespace Help.Script.Help.MultiLanguageSystem.Component
{
    public interface IPermanentMultiLanguageText
    {
        void UpdateLanguage();
    }
    public class PermanentMultiLanguageText : MonoBehaviour,IPermanentMultiLanguageText
    {
        [SerializeField] private RTLTextMeshPro _text;
        [Inject] private IMultiLanguageReference _reference;
    //    [Inject] private IDataManager _dataManager;
        [Inject] private SignalBus _signal;
        [SerializeField] private string _translationId;
        private void Start()
        {
         //   _signal.Subscribe<PlayerDataResolvedSignal>(UpdateLanguage);
            
            if (_text is null)
                _text = GetComponent<RTLTextMeshPro>();
            UpdateLanguage();
        }

        public void UpdateLanguage()
        {
          //  var result=_reference.GetText(_translationId,_dataManager.PlayerData.Language);
       //   _text.UpdateValue((result.text,result.font));
        }
    }
}