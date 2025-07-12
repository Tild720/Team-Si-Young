using System.Collections;
using System.Collections.Generic;
using Core.Scripts;
using NUnit.Framework;
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
        public UnityEvent onChoiceChatSent;
        public UnityEvent onChatClosed;
        private ChatSO currentChatSO;
        private int index = 0; 
        private bool isReady = true;
        private bool isClosed = false;
        private bool isChoising = false;
        private Chat currentChoice;

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

        public void ChoiceMessage(Choice choice)
        {
            StartCoroutine(ChoiceFlow(choice));
        }

        private IEnumerator ChoiceFlow(Choice choice)
        {
            isChoising = true;
            List<Chat> choiceList = choice.response;
            
            Chat choiceChat = new Chat();
                
            choiceChat.message = choice.message;
            choiceChat.chatType = ChatType.ChoiceChat;
            choiceChat.time = 1;
            
            onChatSent.Invoke(choiceChat);
            
            yield return new WaitUntil(() => isReady);

            for (int i = 0; i < choiceList.Count; i++)
            {
                Chat chat = new Chat();
                
                chat.message = choiceList[i].message;
                chat.chatType = choiceList[i].chatType;
                chat.time = choiceList[i].time;
            
            
                onChatSent.Invoke(chat);    
                yield return new WaitUntil(() => isReady);
                yield return new WaitForSeconds(chat.time + 2 );
            }
            isChoising = false;
        }
        
        public void LoadMessages(ChatHistory chatHistory)
        {
            onChatLoaded.Invoke(chatHistory);
        }

        public Chat GetChoice()
        {
            return currentChoice;
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
                if (chat.chatType == ChatType.ChoiceChat)
                {
                    onChoiceChatSent.Invoke();
                    currentChoice = chat;
                }
                else
                {
                    onChatSent.Invoke(chat);
                    
                }
                
                yield return new WaitUntil(() => isReady && !isChoising);
            }
        }
    }
}