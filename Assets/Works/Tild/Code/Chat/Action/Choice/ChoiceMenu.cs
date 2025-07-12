using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
    public class ChoiceMenu : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        [SerializeField] private GameObject choiceBtnPrefab;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        
        public void OnGeneralClicked()
        {
            print("what happened?");
            
            List<Choice> choiceList = ChatManager.Instance.GetChoice().choices;
            foreach (Choice choice in choiceList)
            {
                print(choice.message);
                ChoiceBtn prefab = Instantiate(choiceBtnPrefab, transform).GetComponent<ChoiceBtn>();
                prefab.Initialize(choice);
                
            }
            
        }
        public void OnMoneyClicked()
        {
            
        }
    }
}