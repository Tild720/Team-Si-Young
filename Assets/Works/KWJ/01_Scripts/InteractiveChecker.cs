using System;
using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class InteractiveChecker : MonoBehaviour
    {
        public GameObject InteractiveObject { get; private set; }
        
        [SerializeField] private LayerMask interactiveMask;
        [SerializeField] private float radius;

        private void Update()
        {
            InteractiveCheck();
        }

        public bool InteractiveCheck()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, interactiveMask);
            
            if (colliders.Length > 0)
            {
                if(colliders[0] != null)
                    InteractiveObject = colliders[0].gameObject;
                print(InteractiveObject == null);
                return true;
            }
            
            InteractiveObject = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}