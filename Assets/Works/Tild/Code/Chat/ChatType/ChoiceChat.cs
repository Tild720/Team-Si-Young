using UnityEngine;

namespace Tild.Chat
{
    [CreateAssetMenu(menuName = "Chat/ChoiceChat")]
    public class Choice : Chat
    {
        [SerializeField] private string message;
        public override string Message => message;

        public string Response;
        public int Point;
    }
}