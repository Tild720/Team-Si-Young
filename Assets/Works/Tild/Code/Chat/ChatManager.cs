using System.Collections;
using System.Collections.Generic;
using Core.Scripts;
using UnityEngine;
using UnityEngine.Events;
using Tild.Chat;
using Unity.VisualScripting;

namespace Tild.Chat
{
    public class ChatManager : MonoSingleton<ChatManager>
    {
        public UnityEvent<Chat> onChatSent;
        public UnityEvent<ChatHistory> onChatLoaded;

        public UnityEvent onChatClosed;
        private ChatSO currentChatSO;
        private int index = 0; 
        private bool isReady = true;
        private bool isClosed = false;

        private Dictionary<string, ChatHistory> chatHistories = new();
        
        public void StartChat(ChatSO getChatSO) 
        {
            isReady = true;
            currentChatSO = getChatSO;
            
            if (chatHistories.ContainsKey(getChatSO.NpcId))
            {
                LoadMessages(chatHistories[getChatSO.NpcId]);
            }
            else
            {
                StartCoroutine(MessageFlow());
            }
            
        }
        public void LoadMessages(ChatHistory chatHistory)
        {
            onChatLoaded.Invoke(chatHistory);
        }
        
       
        public void CloseChat() 
        {
            isReady = false;
            onChatClosed.Invoke();
        }
        public void GetReady()
        {
            isReady = true;
        }
        IEnumerator MessageFlow()
        {
            foreach (Chat chat in currentChatSO.ChatFlow)
            {
                isReady = false;
                onChatSent.Invoke(chat);
                yield return new WaitUntil(() => isReady);
            }
        }
    }
}