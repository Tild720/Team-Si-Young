using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

namespace Tild.Chat
{

    [CreateAssetMenu(fileName = "ChatMessagesSO", menuName = "SO/ChatSO", order = 0)]
    public class ChatSO : ScriptableObject
    {
        public ChatInfo chatInfo;
        public int chatID;

        private void OnValidate()
        {
       
            string json = JsonUtility.ToJson(chatInfo, true);

#if UNITY_EDITOR
       
            string path = Application.dataPath + "/Resources/" + chatID + "Chat.txt";
            File.WriteAllText(path, json);
            Debug.Log($"ChatInfo 저장됨: {path}");

           
            AssetDatabase.Refresh();
#endif
        }
    }

}