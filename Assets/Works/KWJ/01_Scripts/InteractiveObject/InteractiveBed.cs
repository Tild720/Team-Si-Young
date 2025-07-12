using UnityEngine;
using UnityEngine.Events;

namespace Works.KWJ._01_Scripts.InteractiveObject
{
    public class InteractiveBed : MonoBehaviour, IInteractiveObject
    {
        public UnityEvent DayCountEvent;
        public void Interact()
        {
            FadeInOut.Instance.FadeOutIn(true, true);
            DayCountEvent?.Invoke();
        }
    }
}