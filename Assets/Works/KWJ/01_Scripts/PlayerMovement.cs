using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Rigidbody rigidbody;
        
        [SerializeField] private float speed;
        
        private Vector3 _moveInput;
        
        private void OnEnable()
        {
            player.playerInput.OnMoveAction += OnMovement;
        }

        private void OnDisable()
        {
            player.playerInput.OnMoveAction -= OnMovement;
        }
        
        private void FixedUpdate()
        {
            rigidbody.linearVelocity = _moveInput.normalized * speed;
        }
        private void OnMovement(Vector2 obj)
        {
            _moveInput = new Vector3(obj.x, 0, obj.y);
        }
    }
}