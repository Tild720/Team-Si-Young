using Unity.Cinemachine;
using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public PlayerInputSo PlayerInput;
        [field:SerializeField] public PlayerMovement PlayerMovement;
        [field: SerializeField] public PlayerInteraction PlayerInteraction;
        [field: SerializeField] public InteractiveChecker InteractiveChecker;

        [field: SerializeField] public CinemachineCamera Camera;

        [field: SerializeField] public Transform HeadPoint;

        public bool IsDontAction { get; set; }
    }
}