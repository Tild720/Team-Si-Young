using System.Collections;
using Core.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Works.KWJ._01_Scripts
{
    public class FadeInOut : MonoSingleton<FadeInOut>
    {
        [SerializeField] private Image _fadeObject;
        
        [SerializeField] private float _fadeValue = 0.01f;
        
        private bool _isFadeing = false;
        public void FadeOutIn(bool isFadeOut = false, bool isFadeImmediately = false)
        {
            if(_isFadeing) return;
            
            PlayerManager.Instance.Player.IsDontAction = true;
            
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
                alpha.a -= _fadeValue;
                _fadeObject.color = alpha;
                yield return null;
            }

            alpha.a = 0f;
            _fadeObject.color = alpha;

            if (isFadeImmediately == true)
            {
                StartCoroutine(WaitSeconds());
                StartCoroutine(FadeOut());
            }
            else
            {
                _isFadeing = false;
                PlayerManager.Instance.Player.IsDontAction = _isFadeing;
            }
        }

        private IEnumerator WaitSeconds()
        {
            yield return new WaitForSeconds(1f);
        }
        
        private IEnumerator FadeOut(bool isFadeImmediately = false)
        {
            if(_isFadeing) yield return null;
            
            _isFadeing = true;
            Color alpha = _fadeObject.color;
            
            while (_fadeObject.color.a < 1f)
            {
                alpha.a += _fadeValue;
                _fadeObject.color = alpha;
                yield return null;
            }

            alpha.a = 1f;
            _fadeObject.color = alpha;

            if (isFadeImmediately == true)
            {
                StartCoroutine(WaitSeconds());
                StartCoroutine(FadeIn());
            }
            else
            {
                _isFadeing = false;
                PlayerManager.Instance.Player.IsDontAction = _isFadeing;
            }
        }
    }
}