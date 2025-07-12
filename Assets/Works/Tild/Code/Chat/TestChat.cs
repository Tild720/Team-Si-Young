using System;
using UnityEngine;

namespace Tild.Chat
{
    public class TestChat : MonoBehaviour
    {
        [SerializeField] ChatInfo chatSO;

        private void Start()
        {
            var data = Resources.Load<TextAsset>(3+"Chat");
            chatSO = JsonUtility.FromJson<ChatInfo>(data.text);
            ChatManager.Instance.StartChat(chatSO);
        }
    }
}