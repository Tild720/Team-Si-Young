using Unity.Cinemachine;
using UnityEngine;
using Works.KWJ._01_Scripts.InteractiveObject;

namespace Works.KWJ._01_Scripts
{
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public PlayerInputSo playerInput;
        [field:SerializeField] public PlayerMovement playerMovement;
        [field: SerializeField] public PlayerInteraction playerInteraction;
        [field: SerializeField] public InteractiveChecker interactiveChecker;

        [field: SerializeField] public CinemachineCamera Camera;
    }
}