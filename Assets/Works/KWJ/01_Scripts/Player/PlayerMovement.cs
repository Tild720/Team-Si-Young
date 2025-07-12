using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Rigidbody rigidbody;
        
        [SerializeField] private float speed;
        [SerializeField] private float cameraSmooth;
        
        private Vector3 _lookRotation;
        
        private Vector3 _moveInput;
        private Vector3 _lookInput;
        
        private void OnEnable()
        {
            player.playerInput.OnLookAroundAction += LookAround;
            player.playerInput.OnMoveAction += OnMovement;
            player.playerInput.AtLootAction += OnLookAt;
        }
        
        private void OnDisable()
        {
            player.playerInput.OnLookAroundAction -= LookAround;
            player.playerInput.OnMoveAction -= OnMovement;
            player.playerInput.AtLootAction -= OnLookAt;
        }

        private void Update()
        {
            _lookRotation += new Vector3(_lookInput.y, _lookInput.x);
            
            _lookRotation.x = Mathf.Clamp(_lookRotation.x, -90, 90);
            
            Quaternion currentRotation = player.Camera.transform.localRotation;
            Quaternion targetRotation = Quaternion.Euler(-_lookRotation.x, _lookRotation.y, 0);
            Quaternion cameraRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cameraSmooth);

            player.Camera.transform.localRotation = cameraRotation;
        }

        private void FixedUpdate()
        {
            Quaternion cameraRotationY = Quaternion.Euler(0, player.Camera.transform.localEulerAngles.y, 0);
            rigidbody.linearVelocity = cameraRotationY * _moveInput.normalized * speed;
        }
        
        private void OnLookAt(Vector2 obj)
        {
            _lookInput = obj;
        }
        
        private void LookAround(bool obj)
        {
            
        }

        private void OnMovement(Vector2 obj)
        {
            _moveInput = new Vector3(obj.x, 0, obj.y);
        }
    }
}