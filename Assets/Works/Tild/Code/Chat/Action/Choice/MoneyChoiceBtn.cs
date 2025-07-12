using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Works.KWJ._01_Scripts.SO;

namespace Tild.Chat
{
    public class MoneyChoiceBtn : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private RectTransform rectTransform;
        private FraudSkillSo currentChoice;
        public void Initialize(FraudSkillSo choice)
        {
            currentChoice = choice;
            text.SetText(choice.SkillName);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            
            rectTransform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 0.2f).OnComplete(() =>
            {
                rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f); 
               
            });
            ChatManager.Instance.MoneyChoiceMessage(currentChoice);
            
        }

      
    }
}