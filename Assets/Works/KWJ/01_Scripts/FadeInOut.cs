using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Works.KWJ._01_Scripts
{
    public class FadeInOut : MonoBehaviour
    {
        [SerializeField] private Image _fadeObject;

        private void Start()
        {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeIn()
        {
            Color alpha = _fadeObject.color;
            
            while (_fadeObject.color.a > 0f)
            {
                alpha.a -= 0.01f;
                _fadeObject.color = alpha;
                yield return null;
            }

            alpha.a = 0f;
            _fadeObject.color = alpha;
        }
        
        private IEnumerator FadeOut()
        {
            Color alpha = _fadeObject.color;
            
            while (_fadeObject.color.a < 1f)
            {
                alpha.a += 0.01f;
                _fadeObject.color = alpha;
                yield return null;
            }

            alpha.a = 1f;
            _fadeObject.color = alpha;
        }
    }
}