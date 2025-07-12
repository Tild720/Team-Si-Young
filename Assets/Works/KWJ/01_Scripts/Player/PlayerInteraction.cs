using UnityEngine;
using Works.KWJ._01_Scripts.InteractiveObject;

namespace Works.KWJ._01_Scripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        private void OnEnable()
        {
            player.PlayerInput.OnInteractionAction += OnInteraction;
        }

        private void OnDisable()
        {
            player.PlayerInput.OnInteractionAction -= OnInteraction;
        }
        
        private void OnInteraction()
        {
            if (player.PlayerMovement.IsComputerView == true)
            {
                player.Camera.Follow = player.HeadPoint;
                player.PlayerMovement.IsComputerView = false;
                return;
            }
            
            if(player.IsDontAction) return;
            
            if (player.InteractiveChecker.InteractiveCheck())
            {
                if (player.InteractiveChecker.InteractiveObject
                    .TryGetComponent<IInteractiveObject>(out var interactable))
                {
                    InteractiveObjectCheck();
                    
                    interactable.Interact();
                }
            }
        }

        private void InteractiveObjectCheck()
        {
            if (player.InteractiveChecker.InteractiveObject.
                TryGetComponent<InteractiveComputer>(out var computer))
            {
                if (player.PlayerMovement.IsComputerView == false)
                {
                    player.Camera.Follow = computer.CameraPoint;
                    player.PlayerMovement.IsComputerView = true;
                }
            }
            
            
            
        }
    }
}