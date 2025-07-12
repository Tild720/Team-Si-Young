using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
  
    [System.Serializable]
    public class Choice
    {
        public ChatType chatType = ChatType.ChoiceChat;

        [TextArea]
        public string message;
        [TextArea]
        public List<Chat> response;
        public int point;
    }
}