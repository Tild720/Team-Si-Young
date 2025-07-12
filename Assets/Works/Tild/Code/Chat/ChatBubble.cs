using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Tild.Chat
{
    public class ChatBubble : MonoBehaviour 
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text chatText;
        public void Initialize(Chat chat)
        {
            canvasGroup.DOFade(1, 0.2f);
            canvasGroup.transform.DOScale(1, 0.2f).SetDelay(1).OnComplete(() =>
            {
                ChatManager.Instance.GetReady();
            });
            chatText.SetText(chat.message);
        }
        
    }
}