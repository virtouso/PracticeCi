using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Help.Script.Help.Components
{
    public class AnimButton : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] protected Button button;
        public virtual void Show(UnityAction action,string id)
        {
            button.onClick.AddListener(action);
            button.onClick.AddListener(() => animator.Play(AnimButtonConsts.PressAnimation));
            IdOrAnswer = id;
        }

        public virtual void Hide()
        {
            button.onClick.RemoveAllListeners();
        }

        public void SetInteraction(bool interactable)
        {
            button.interactable = interactable;
        }

        public void ShowSuccess()
        {
            animator.Play(AnimButtonConsts.SuccessAnimation);
        }

        public void ShowFail()
        {
            animator.Play(AnimButtonConsts.FailAnimation);
        }
        
        
        public string IdOrAnswer { get;private set; }

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            animator = GetComponent<Animator>();
        }
    }

    public static class AnimButtonConsts
    {
        public static readonly string PressAnimation = "press";
        public static readonly string SuccessAnimation = "success";
        public static readonly string FailAnimation = "fail";
    }
}