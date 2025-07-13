using System;
using Core.Scripts;
using UnityEngine;

namespace Works.KWJ._01_Scripts.InteractiveObject
{
    public class InteractiveComputer : MonoBehaviour, IInteractiveObject
    {
        [field:SerializeField] public Transform CameraPoint { get; private set; }

        private void Start()
        {
            SoundManager.Instance.PlaySFX("Computer", transform, true);
        }

        public void Interact()
        {
            
        }
    }
}