using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class InteractiveComputer : MonoBehaviour, IInteractiveObject
    {
        public void Interact()
        {
            print(gameObject.name);
        }
    }
}