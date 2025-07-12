using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
    [CreateAssetMenu(fileName = "ChatMessagesSO", menuName = "SO/ChatSO", order = 0)]
    public class ChatSO : ScriptableObject
    {
        public string NpcId;
        public List<Chat> ChatFlow;
        public List<Chat> MoneySuccess;
        public List<Chat> MoneyFail;
        public List<Chat> StopChatResponse;
    }
}