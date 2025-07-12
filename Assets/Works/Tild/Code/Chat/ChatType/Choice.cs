using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
  
    [System.Serializable]
    public class Choice
    {
        public ChatType chatType = ChatType.ChoiceChat;

        [TextArea]
        [SerializeField]
        public string message;
        public string Message => message;
        
        public List<Chat> response;
        public int point;
    }
}