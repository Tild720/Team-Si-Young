using Unity.Cinemachine;
using UnityEngine;
using Works.KWJ._01_Scripts.UI;

namespace Works.KWJ._01_Scripts
{
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public PlayerInputSo PlayerInput;
        [field:SerializeField] public PlayerMovement PlayerMovement;
        [field: SerializeField] public PlayerInteraction PlayerInteraction;
        [field: SerializeField] public InteractiveChecker InteractiveChecker;
        [field: SerializeField] public ItemInventory ItemInventory;
        [field: SerializeField] public PlayerHunger PlayerHunger;
        [field: SerializeField] public PlayerMoney PlayerMoney;
        
        [field: SerializeField] public CinemachineCamera Camera;

        [field: SerializeField] public Transform HeadPoint;
        
        [field: SerializeField] public Transform ComputerPoint;

        public bool IsDontAction { get; set; }
    }
}