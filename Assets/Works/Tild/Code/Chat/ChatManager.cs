using Core.Scripts;
using UnityEngine.Events;

namespace Tild.Chat
{
    public class ChatManager : MonoSingleton<ChatManager>
    {
        public UnityEvent<Chat> onChatSent;

        public void SendChatMessage(ChatMessagesSO chatMessagesSO)
        {
            
        }

    }
}