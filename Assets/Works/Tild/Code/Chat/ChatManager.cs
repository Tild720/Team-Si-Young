using System.Collections;
using System.Collections.Generic;
using Core.Scripts;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using Tild.Chat;
using Unity.VisualScripting;
using UnityEngine.UI;
using Works.KWJ._01_Scripts.SO;

namespace Tild.Chat
{
    public class ChatManager : MonoSingleton<ChatManager>
    {
        public UnityEvent<Chat> onChatSent;
        public UnityEvent<ChatHistory> onChatLoaded;
        public UnityEvent onChoiceChatSent;
        public UnityEvent onChatClosed;
        public UnityEvent onChoiced;
        private ChatInfo currentChatSO;
        private int currentTrust = 0;
        
        private int index = 0; 
        private bool isReady = true;
        private bool isClosed = false;
        private bool isChoising = false;
        private Chat currentChoice;
        private bool isOver;

        [SerializeField] private GameObject chatGUI;
        [SerializeField] private GameObject exploreGUI;
        [SerializeField] private Image fadeImage;

        private Dictionary<string, ChatHistory> chatHistories = new();
        
        public void StartChat(ChatInfo getChatSO) 
        {
            isReady = true;
            currentChatSO = getChatSO;
            currentTrust = 0;
            isOver = false;
            currentChoice = null;
            isChoising = false;
            
            if (chatHistories.ContainsKey(getChatSO.NpcId))
            {
                LoadMessages(chatHistories[getChatSO.NpcId]);
            }
            else
            {
                StartCoroutine(MessageFlow(getChatSO.ChatFlow));
            }
            
        }

        public void ChoiceMessage(Choice choice)
        {
            onChoiced.Invoke();
            StartCoroutine(ChoiceFlow(choice));
        }

        public void MoneyChoiceMessage(FraudSkillSo fraudSkillSo)
        {
            onChoiced.Invoke();
            if (fraudSkillSo.SkillName == currentChatSO.favorite)
            {

                StartCoroutine(MessageFlow(currentChatSO.MoneySuccess));
            }
            else
            {
                List<Chat> newChat = new List<Chat>();
                newChat.Add(currentChatSO.MoneySuccess[0]);
                foreach (var chat in currentChatSO.MoneyFail)
                    StartCoroutine(MessageFlow(newChat));
            }


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
            fadeImage.DOFade(1, 0.5f).SetDelay(2.5f).OnComplete(() =>
            {  
                chatGUI.SetActive(false);
                exploreGUI.SetActive(true); 
                
            });
        }
        public void GetReady()
        {
            isReady = true;
        }
        IEnumerator MessageFlow(List<Chat> flow)
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
                    currentTrust += chat.point;
                    if (currentTrust < -100)
                    {
                        isOver = true;
                        Chat newChat = new Chat();
                        newChat.message = "상대방에게 차단당했습니다.";
                        onChatSent.Invoke(chat);
                        CloseChat();
                        yield break;
                    }
                    
                    onChatSent.Invoke(chat);
                   

                }

                yield return new WaitUntil(() => isReady && !isChoising && !isOver);
            }
        }
    }
}