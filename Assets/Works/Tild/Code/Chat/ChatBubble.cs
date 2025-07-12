using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tild.Chat
{
    public class ChatBubble : MonoBehaviour 
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text chatText;

        public void Initialize(Chat chat)
        {
           
            chatText.SetText(chat.message);

            if (chat.message.Contains("\n"))
            {
              
                RectTransform rt = canvasGroup.GetComponent<RectTransform>();


                LayoutGroup layout = rt.GetComponent<LayoutGroup>();
                if (layout != null) layout.enabled = false;

                ContentSizeFitter csf = rt.GetComponent<ContentSizeFitter>();
                if (csf != null) csf.enabled = false;


                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 150f);


                LayoutRebuilder.ForceRebuildLayoutImmediate(rt);

               
            }

   
            canvasGroup.DOFade(1, 0.2f);
            canvasGroup.transform.DOScale(1, 0.2f).SetDelay(1).OnComplete(() =>
            {
                ChatManager.Instance.GetReady();
            });
        }
    }
}