using UnityEngine;
using Works.KWJ._01_Scripts.InteractiveObject;

namespace Works.KWJ._01_Scripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        private void OnEnable()
        {
            player.playerInput.OnInteractionAction += OnInteraction;
        }

        private void OnDisable()
        {
            player.playerInput.OnInteractionAction -= OnInteraction;
        }
        
        private void OnInteraction()
        {
            if (player.interactiveChecker.InteractiveCheck())
            {
                if (player.interactiveChecker.InteractiveObject
                    .TryGetComponent<IInteractiveObject>(out var interactable))
                {
                    interactable.Interact();
                }
            }
        }

    }
}