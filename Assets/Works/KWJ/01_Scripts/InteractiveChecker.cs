using System;
using ExternAssets.QuickOutline.Scripts;
using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class InteractiveChecker : MonoBehaviour
    {
        public GameObject InteractiveObject { get; private set; }
        [SerializeField] private Player player;
        [SerializeField] private Outline outline;
        
        [SerializeField] private LayerMask interactiveMask;
        [SerializeField] private float range;

        private void Update()
        {
            InteractiveCheck();
        }

        private void OnDisable()
        {
            outline.OnUnfocus();
        }

        public bool InteractiveCheck()
        {
            if (Physics.Raycast(player.Camera.transform.position, player.Camera.transform.forward,
                    out RaycastHit hit, range, interactiveMask))
            {
                outline.OnUnfocus();
                InteractiveObject = hit.transform.gameObject;
                outline.OnFocus(hit.collider.gameObject);
                return true;
            }
            
            outline.OnUnfocus();
            InteractiveObject = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(player.Camera.transform.position, player.Camera.transform.forward * range);
        }
    }
}