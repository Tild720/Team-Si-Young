using UnityEngine;

namespace Tild.Chat
{
    [CreateAssetMenu(menuName = "Chat/AlertChat")]
    public class AlertChat : Chat
    {
        [SerializeField] private string message;
        public override string Message => message;
    }
}