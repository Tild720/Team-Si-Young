using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Tild.Chat
{
    public class ChatVisual : MonoBehaviour
    {
        
        private ScrollRect scrollRect; 
        
        [SerializeField] private Image FadeImage;
        [SerializeField] private GameObject chatParent;
        [SerializeField] private GameObject myChatPrefab, targetPrefab,alertPrefab, loadMyChatPrefab, loadtargetPrefab, loadAlertPrefab;

        public void ShowChat(Chat chat)
        {
            switch (chat.chatType)
            {
                case ChatType.TargetChat:
                    ChatBubble TargetChatBubble = Instantiate(targetPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    TargetChatBubble.Initialize(chat);
                    
                    break;
                case ChatType.ChoiceChat:
                    ChatBubble ChoiceChatBubble = Instantiate(myChatPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    ChoiceChatBubble.Initialize(chat);
                    break;
                case ChatType.AlertChat:
                    ChatBubble AlertChatBubble = Instantiate(alertPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    AlertChatBubble.Initialize(chat);
                    break;
            }
        }

        public void CloseChat(Chat chat)
        {

            FadeImage.DOFade(1, 0.3f).OnComplete(() =>
            {
                foreach (Transform child in chatParent.transform)
                {
                    Destroy(child.gameObject);
                }
            });

        }

        public void LoadMessages(ChatHistory chatHistory)
        {
            foreach (Chat lines in ChatHistory.lines)
            {
                switch (lines.chatType)
                {
                    case ChatType.TargetChat:
                        Instantiate(loadtargetPrefab, chatParent.transform);
                        break;
                    case ChatType.ChoiceChat:
                        Instantiate(loadMyChatPrefab, chatParent.transform);
                        break;
                    case ChatType.AlertChat:
                        Instantiate(loadAlertPrefab, chatParent.transform);
                        break;
                }
                
                
            }
        }
    }
}