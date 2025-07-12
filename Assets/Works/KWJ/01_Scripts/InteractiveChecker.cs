using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class InteractiveChecker : MonoBehaviour
    {
        public GameObject InteractiveObject { get; private set; }
        
        [SerializeField] private LayerMask interactiveMask;
        [SerializeField] private float range;

        private void Update()
        {
            InteractiveCheck();
        }

        public bool InteractiveCheck()
        {
            if (Physics.Raycast(transform.position, transform.forward,
                    out RaycastHit hit, range, interactiveMask))
            {
                InteractiveObject = hit.transform.gameObject;
                return true;
            }
            
            InteractiveObject = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * range);
        }
    }
}