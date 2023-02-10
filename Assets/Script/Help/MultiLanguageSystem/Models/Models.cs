using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Help.Script.Help.MultiLanguageSystem.Models
{
    [System.Serializable]
    public class Dialogue
    {
        public string Id;
        public List<Monologue> Monologues;
    }

    [System.Serializable]
    public class Monologue
    {
        public string CharacterId;
        public Word Text;
    }


    [System.Serializable]
    public class Word
    {
        [SerializeField] public string Guid;
        [SerializeField] private List<LanguageTextPair> Translations;

        public string GetText(Language language)
        {
            var result= Translations.FirstOrDefault(x => x.Language == language);
            if (result is null) return "language does not exit";
            return result.Text;
        }
        
        
        
        [System.Serializable]
        public class LanguageTextPair
        {
            public Language Language;
            
            [TextArea] public string Text;
        }
        
    }

    [Serializable]
    public class LanguageFontPair
    {
        public Language Langauge;
        public TMP_FontAsset Font;
        public bool IsRtl;
    }

    public enum Language
    {
        English,
        Persian
    }
}