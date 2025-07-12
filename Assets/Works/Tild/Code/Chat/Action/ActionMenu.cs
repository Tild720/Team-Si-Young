using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Tild.Chat
{
    public class ActionMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private CanvasGroup choiceMenu;
        public UnityEvent onMoneyClicked;
        public UnityEvent onGeneralClicked;

        public void OpenActionMenu()
        {
           
            canvasGroup.DOFade(1, 0.5f);
            canvasGroup.blocksRaycasts = true;
            
        } 
        public void CloseActionMenu()
        {
            canvasGroup.DOFade(0, 0.5f);
            canvasGroup.blocksRaycasts = false;
        }
        public void OpenChoiceMenu()
        {
            canvasGroup.DOFade(0, 0.5f);
            choiceMenu.DOFade(1, 0.5f).SetDelay(0.4f);
            choiceMenu.blocksRaycasts = true;
            canvasGroup.blocksRaycasts = false;
        }

        public void GeneralClicked()
        {
            Debug.Log("asdasd");
            OpenChoiceMenu();
            onGeneralClicked?.Invoke();
        }

        public void MoneyClicked()
        {
            Debug.Log("asdasd222");
            OpenChoiceMenu();
            onMoneyClicked?.Invoke();
          
        }

        
    }
}