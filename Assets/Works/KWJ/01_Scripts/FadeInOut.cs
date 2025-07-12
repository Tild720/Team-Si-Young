using System.Collections;
using Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Works.KWJ._01_Scripts
{
    public class FadeInOut : MonoSingleton<FadeInOut>
    {
        [SerializeField] private Image _fadeObject;
        
        private bool _isFadeing = false;
        public void FadeOutIn(bool isFadeOut = false, bool isFadeImmediately = false)
        {
            if(_isFadeing) return;
            
            if(isFadeOut == true)
                StartCoroutine(FadeOut(isFadeImmediately));
            else
                StartCoroutine(FadeIn(isFadeImmediately));
        }

        private IEnumerator FadeIn(bool isFadeImmediately = false)
        {
            if(_isFadeing) yield return null;
            
            _isFadeing = true;
            Color alpha = _fadeObject.color;
            
            while (_fadeObject.color.a > 0f)
            {
                alpha.a -= 0.01f;
                _fadeObject.color = alpha;
                yield return null;
            }

            alpha.a = 0f;
            _fadeObject.color = alpha;
            
            if(isFadeImmediately == true)
                StartCoroutine(FadeOut());
            else
                _isFadeing = false;
        }
        
        private IEnumerator FadeOut(bool isFadeImmediately = false)
        {
            if(_isFadeing) yield return null;
            
            _isFadeing = true;
            Color alpha = _fadeObject.color;
            
            while (_fadeObject.color.a < 1f)
            {
                alpha.a += 0.01f;
                _fadeObject.color = alpha;
                yield return null;
            }

            alpha.a = 1f;
            _fadeObject.color = alpha;
            
            if(isFadeImmediately == true)
                StartCoroutine(FadeIn());
            else
                _isFadeing = false;
        }
    }
}