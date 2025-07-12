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
        public string response;
        public int point;
    }
}