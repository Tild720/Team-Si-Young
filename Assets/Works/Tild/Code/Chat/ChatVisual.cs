using UnityEngine;
using UnityEngine.UI;

namespace Tild.Chat
{
    public class ChatVisual : MonoBehaviour
    {
        private ScrollRect scrollRect; 
        
        [SerializeField] private GameObject chatParent;
        [SerializeField] private GameObject myChatPrefab;
        [SerializeField] private GameObject targetPrefab;

        public void ShowChat(Chat chat)
        {
            
        }
    }
}