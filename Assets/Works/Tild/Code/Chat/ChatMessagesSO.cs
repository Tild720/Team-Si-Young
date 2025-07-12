using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
    [CreateAssetMenu(fileName = "ChatMessagesSO", menuName = "SO/ChatSO", order = 0)]
    public class ChatMessagesSO : ScriptableObject
    {
        public List<Chat> ChatFlow;
        public List<TargetChat> MoneySuccess;
        public List<TargetChat> MoneyFail;
        public List<TargetChat> StopChatResponse;
    }
}