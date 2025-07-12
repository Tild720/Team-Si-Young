﻿using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<T>();
                    
                    /*
                    if (_instance == null)
                    {
                        GameObject gameObject = new GameObject(typeof(T).Name);
                        _instance = gameObject.AddComponent<T>();
                    }*/
                }
                
                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}