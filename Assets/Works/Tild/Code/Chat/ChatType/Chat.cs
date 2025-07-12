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
        public string message;
        
        public List<Choice> choices;

        public HintType hintType;


    }
}