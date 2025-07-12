using UnityEngine;

namespace Works.KWJ._01_Scripts.InteractiveObject
{
    public class InteractiveBed : MonoBehaviour, IInteractiveObject
    {
        public void Interact()
        {
            print(gameObject.name);
        }
    }
}