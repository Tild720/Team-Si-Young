using System;
using UnityEngine;

namespace Tild.Chat
{
    public class TestChat : MonoBehaviour
    {
        [SerializeField] ChatSO chatSO;

        private void Start()
        {
            ChatManager.Instance.StartChat(chatSO);
        }
    }
}