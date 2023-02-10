using System;
using System.Collections.Generic;
using System.Linq;
using Help.Script.Help.MultiLanguageSystem.Models;
using TMPro;
using UnityEngine;

namespace Help.Script.Help.MultiLanguageSystem.ScriptableObject
{
    public interface IMultiLanguageReference
    {
        public void Init();
        ( string text, TMP_FontAsset font) GetText(string guid, Language language);
        TMP_FontAsset GetFont(Language language);
        ( string text, TMP_FontAsset font) GetNumber(int number, Language language);
    }

    public class MultiLanguageReference : UnityEngine.ScriptableObject, IMultiLanguageReference
    {
        [SerializeField] private List<Word> _basementTextsList;
        private Dictionary<Language, Dictionary<string, string>> _basementTexts;


        [SerializeField] private List<LanguageFontPair> _fontsList;
        private Dictionary<Language, TMP_FontAsset> _fonts;


        public void Init()
        {
            _basementTexts = new Dictionary<Language, Dictionary<string, string>>();
            foreach (Language language in Enum.GetValues(typeof(Language)))
            {
                Dictionary<string, string> keys = new Dictionary<string, string>();
                foreach (var item in _basementTextsList)
                {
                    keys.Add(item.Guid, item.GetText(language));
                }

                _basementTexts[language] = keys;
            }


            _fonts = new Dictionary<Language, TMP_FontAsset>(_fontsList.Count);

            foreach (var item in _fontsList)
            {
                _fonts.Add(item.Langauge, item.Font);
            }
        }

        public ( string text, TMP_FontAsset font) GetText(string guid, Language language)
        {
            if (!_basementTexts[language].ContainsKey(guid))
                return ("no_translation", null);
            var textResult = _basementTexts[language][guid];
            var fontResult = _fonts[language];
            return (textResult, fontResult);
        }

        public TMP_FontAsset GetFont(Language language)
        {
            return _fonts[language];
        }

        public ( string text, TMP_FontAsset font) GetNumber(int number, Language language)
        {
            var stringNumber = number.ToString();

            if (_fontsList.First(x => x.Langauge == language).IsRtl)
                return (GetPersianNumber(stringNumber), _fonts[language]);

            return (stringNumber, _fonts[language]);
        }

        private string GetPersianNumber(string englishNumber)
        {
            string persianNumber = "";
            foreach (char ch in englishNumber)
            {
                persianNumber += (char)(1776 + char.GetNumericValue(ch));
            }

            return persianNumber;
        }
    }
}