using UnityEngine;

namespace Tild.Chat
{
    public abstract class Chat : ScriptableObject
    {
        public abstract string Message { get; }
    }
}