using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

namespace Tild.Chat
{

    [CreateAssetMenu(fileName = "ChatMessagesSO", menuName = "SO/ChatSO", order = 0)]
    public class ChatSO : ScriptableObject
    {
        public ChatInfo chatInfo;
    }

}