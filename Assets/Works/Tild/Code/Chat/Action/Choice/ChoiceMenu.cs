    using System;
    using System.Collections.Generic;
    using DG.Tweening;
    using NUnit.Framework;
    using UnityEngine;
    using Works.KWJ._01_Scripts.SO;

    namespace Tild.Chat
    {
        public class ChoiceMenu : MonoBehaviour
        {
            private CanvasGroup canvasGroup;
            [SerializeField] private GameObject choiceBtnPrefab;
            [SerializeField] private GameObject MoneyChoiceBtnPrefab;

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

            public void RemoveChoices()
            {
                canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
                {
                    for (int i = canvasGroup.transform.childCount - 1; i >= 0; i--)
                    {
                        Destroy(canvasGroup.transform.GetChild(i).gameObject);
                    }
                });
                canvasGroup.blocksRaycasts = false;
            }
            public void OnMoneyClicked()
            {
                canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
                {
                    List<FraudSkillSo> list = new List<FraudSkillSo>();
                    foreach (FraudSkillSo fraudSkill in list)
                    {
                        print(fraudSkill.SkillName);
                        MoneyChoiceBtn prefab = Instantiate(MoneyChoiceBtnPrefab, transform).GetComponent<MoneyChoiceBtn>();
                        prefab.Initialize(fraudSkill);
                    
                    }

                });
                canvasGroup.blocksRaycasts = false;
            }
        }
    }