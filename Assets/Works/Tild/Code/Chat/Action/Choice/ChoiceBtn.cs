using DG.Tweening;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tild.Chat
{
    public class ChoiceBtn : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler
    {  
        [SerializeField] private TMP_Text text;
        [SerializeField] private RectTransform rectTransform;

        private Choice currentChoice;
        
        public void Initialize(Choice choice)
        {
            currentChoice = choice;
            text.SetText(choice.message);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            
            rectTransform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 0.2f).OnComplete(() =>
            {
                rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f); 
                print(currentChoice.message);
               
            });
            ChatManager.Instance.ChoiceMessage(currentChoice);
            ChatManager.Instance.currentTrust += currentChoice.point;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            rectTransform.rotation = new Quaternion(0,0,0,0);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            rectTransform.rotation = new Quaternion(0,0,15,0);
        }
    }
}