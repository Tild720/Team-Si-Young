using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
    [Serializable]
    public class ChatInfo
    {
        public string NpcId;
        public Sprite image;
        public string age;
        public string name;
        public string job;
        public string address;
        public string favorite;
        public List<Chat> ChatFlow;
        public List<Chat> MoneySuccess;
        public List<Chat> MoneyFail;
        public List<Chat> StopChatResponse;


    }
}