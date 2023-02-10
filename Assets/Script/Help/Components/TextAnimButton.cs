using System;
using RTLTMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Help.Script.Help.Components
{
    public class TextAnimButton : AnimButton
    {
        [SerializeField] private RTLTextMeshPro _text;
        
        public  void Show(UnityAction action,string text, string id)
        {
            base.Show(action,id);
            _text.text = text;
        }


        protected override void Awake()
        {
            base.Awake();
            _text = GetComponentInChildren<RTLTextMeshPro>();
        }
    }
}