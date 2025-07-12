using UnityEngine;

namespace Works.KWJ._01_Scripts.InteractiveObject
{
    public class InteractiveComputer : MonoBehaviour, IInteractiveObject
    {
        [field:SerializeField] public Transform CameraPoint { get; private set; }

        public void Interact()
        {
            
        }
    }
}