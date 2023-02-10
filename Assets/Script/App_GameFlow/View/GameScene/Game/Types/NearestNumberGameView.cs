using System.Collections.Generic;
using System.Linq;
using App.Script.App_GameFlow.Controller;
using Cysharp.Threading.Tasks;
using GameLogics.GamePlay.NearestNumber;
using Help.Script.Help.Components;
using Help.Script.Help.Extensions;
using Newtonsoft.Json;
using RTLTMPro;
using Shared.Basic.DTO.Game.Request;
using Shared.Basic.DTO.Game.Signal;
using Shared.Basic.Enums;
using UnityEngine;
using Zenject;

namespace App.Script.App_GameFlow.View.GameScene.Game.Types
{
    public class NearestNumberGameView : BaseGameView
    {
        [SerializeField] private RTLTextMeshPro _questionTitleText;
        [SerializeField] private TextAnimButton _buttonPrefab;
        [SerializeField] private Transform _buttonsParent;

        [Inject] private ILogger _logger;
        
        private readonly List<TextAnimButton> _options = new List<TextAnimButton>();
     [Inject]   private DiContainer _container;
     [Inject] private readonly IDataController _dataController;
        
        
        protected override async void ShowQuestion(GameQuestionResponseSignal signal)
        {
            
            
            var deserialized = JsonConvert.DeserializeObject<NearestNumberGamePlay.Question>(signal.Data.Data);

            _questionTitleText.text = deserialized.Title;

            foreach (var item in _options)
            {
                item.SetInteraction(true);
                item.gameObject.CheckedSetActive(false);
            }
            
            for (int i = 0; i < deserialized.Options.Count; i++)
            {
                if (_options.Count - 1 < i)
                {
                    var instance = _container.InstantiatePrefabForComponent<TextAnimButton>(_buttonPrefab);
                //    instance.gameObject.CheckedSetActive(true);
                    //instance.gameObject.CheckedSetEnabled(_buttonsParent);
                    instance.transform.CheckedSetParent(_buttonsParent);
                    _options.Add(instance);
                }

                _options[i].gameObject.CheckedSetActive(true);
                var i1 = i;
                _options[i].Show(() => SendAnswer(new GameAnswerRequest(GamePlayNames.NearestNumber, deserialized.Options[i1],_dataController.GetUserIdentity().id)),deserialized.Options[i1] ,deserialized.Options[i1]);
                await UniTask.Delay(300);
            }
        }

        private string _cachedAnswer;

        protected override void ShowAnswer(GameAnswerResponseSignal signal)
        {
            if (signal.Data.Data == _cachedAnswer)
            {
                //todo success. you can play song
                _options.First(x => x.IdOrAnswer == _cachedAnswer).ShowSuccess();
            }
            else
            {
                //todo failed
                _options.First(x => x.IdOrAnswer == _cachedAnswer).ShowFail();
                _options.First(x => x.IdOrAnswer == signal.Data.Data).ShowSuccess();
            }
        }

        protected override void ShowStart(RoundStartResponseSignal signal)
        {
            
            _logger.ShowErrorLog("nearest number match started", Color.green, Channels.GameFlow);
        }

        private void SendAnswer(GameAnswerRequest request)
        {
            _cachedAnswer = request.Answer;
            ChangeButtonsInteraction(false);
            GamePlayController.RequestGameAnswer(request);
        }


        private void ChangeButtonsInteraction(bool interact)
        {
            foreach (var item in _options)
            {
                item.SetInteraction(interact);
            }
        }
    }
}