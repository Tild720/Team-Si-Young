using System;
using System.Collections;
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

        private void Awake()
        {
            scrollRect = GetComponentInChildren<ScrollRect>();
        }

        public void ShowChat(Chat chat)
        {
            WaitChat(chat.time);
            scrollRect.velocity = Vector2.one;
            switch (chat.chatType)
            {
                    
                case ChatType.TargetChat:
                    ChatBubble TargetChatBubble = Instantiate(targetPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    TargetChatBubble.Initialize(chat);
                    
                    break;
                case ChatType.ChoiceChat:
                    if (chat.message == "")
                    {
                        ChatManager.Instance.GetReady(); 
                        return;
                    }
                    ChatBubble ChoiceChatBubble = Instantiate(myChatPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    ChoiceChatBubble.Initialize(chat);
                    
                    break;
                case ChatType.AlertChat:
                    ChatBubble AlertChatBubble = Instantiate(alertPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    AlertChatBubble.Initialize(chat);
                    break;
                case ChatType.MyChat:
                    
                    ChatBubble MyChatBubble = Instantiate(myChatPrefab, chatParent.transform).transform.GetComponent<ChatBubble>();
                    MyChatBubble.Initialize(chat);
                    break;
                case ChatType.WaitChat:
                    
                    break;
            }
        }

        private IEnumerator WaitChat(float time)
        {
            yield return new WaitForSeconds(time);
            ChatManager.Instance.GetReady();
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