using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Tild.Chat
{
    [System.Serializable]
    public class Chat
    {
        public ChatType chatType;

        [TextArea]
        [SerializeField]
        public string message;
        public string Message => message;
        public int point;
        public List<Choice> choices;
        public int time = 1;
        public HintType hintType;


    }
}