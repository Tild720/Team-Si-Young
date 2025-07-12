using UnityEngine;

namespace Tild.Chat
{
    [CreateAssetMenu(menuName = "Chat/TargetChat")]
    public class TargetChat : Chat
    {
        [SerializeField] private string message;
        public override string Message => message;
    }
}