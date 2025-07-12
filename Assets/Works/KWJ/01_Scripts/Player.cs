using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public PlayerInputSo playerInput;
        [field:SerializeField] public PlayerMovement playerMovement;
        [field: SerializeField] public PlayerInteraction playerInteraction;
        [field: SerializeField] public InteractiveChecker interactiveChecker;

    }
}