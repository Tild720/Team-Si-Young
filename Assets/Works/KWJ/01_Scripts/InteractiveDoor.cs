using System.Collections;
using UnityEngine;
using Works.KWJ._01_Scripts.InteractiveObject;

namespace Works.KWJ._01_Scripts
{
    public class InteractiveDoor : MonoBehaviour, IInteractiveObject
    {
        private bool _isOpen = false;
        private bool _isMoving = false;

        public void Interact()
        {
            if (_isMoving) return; 

            StopAllCoroutines();
            StartCoroutine(RotateDoor(_isOpen ? 110f : 0f, _isOpen ? 0f : 110f));
            _isOpen = !_isOpen;
        }

        private IEnumerator RotateDoor(float fromAngle, float toAngle)
        {
            _isMoving = true;

            float elapsed = 0f;
            float duration = 1f;

            Quaternion fromRot = Quaternion.Euler(0, fromAngle, 0);
            Quaternion toRot = Quaternion.Euler(0, toAngle, 0);

            while (elapsed < duration)
            {
                transform.localRotation = Quaternion.Lerp(fromRot, toRot, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localRotation = toRot;

            _isMoving = false;

            if (toAngle == 110f)
            {
                yield return new WaitForSeconds(3f);
                Interact();
            }
        }
    }
}