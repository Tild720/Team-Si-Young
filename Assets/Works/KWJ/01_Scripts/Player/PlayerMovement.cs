using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool IsComputerView { get; set; }
        
        [SerializeField] private Player player;
        [SerializeField] private Rigidbody rigidbody;
        
        [SerializeField] private float speed;
        [SerializeField] private float cameraSmooth;
        
        private Vector3 _lookRotation;
        
        private Vector3 _moveInput;
        private Vector3 _lookInput;
        
        private bool _isDontLookAt;
        
        private void OnEnable()
        {
            player.PlayerInput.OnLookAroundAction += LookAround;
            player.PlayerInput.OnMoveAction += OnMovement;
            player.PlayerInput.AtLootAction += OnLookAt;
        }
        
        private void OnDisable()
        {
            player.PlayerInput.OnLookAroundAction -= LookAround;
            player.PlayerInput.OnMoveAction -= OnMovement;
            player.PlayerInput.AtLootAction -= OnLookAt;
        }

        private void Update()
        {
            if (player.IsDontAction == true)
            {
                _lookInput = Vector3.zero;
                _moveInput = Vector3.zero;
            }
            
            if (IsComputerView == true)
            {
                _moveInput = Vector3.zero;
            }
            
            _lookRotation += new Vector3(_lookInput.y, _lookInput.x);
            
            if (IsComputerView == true)
            {
                _lookRotation.x = Mathf.Clamp(_lookRotation.x, -40f, 40f);
                _lookRotation.y = Mathf.Clamp(_lookRotation.y, -130f, -50f);
            }
            else
            {
                _lookRotation.x = Mathf.Clamp(_lookRotation.x, -90f, 90f);
            }

            if (IsComputerView == true)
            {
                if (_isDontLookAt == true)
                {
                    CameraRotation();
                }
                else
                {
                    Quaternion currentRotation = player.Camera.transform.localRotation;
                    
                    player.Camera.transform.localRotation = Quaternion.Lerp(currentRotation, 
                                        Quaternion.Euler(0, -90, 0), Time.deltaTime * cameraSmooth);
                }
            }
            else
            {
                CameraRotation();
            }
        }
        private void FixedUpdate()
        {
            Quaternion cameraRotationY = Quaternion.Euler(0, player.Camera.transform.localEulerAngles.y, 0);
            rigidbody.linearVelocity = cameraRotationY * _moveInput.normalized * speed;
        }

        private void CameraRotation()
        {
            Quaternion currentRotation = player.Camera.transform.localRotation;
            Quaternion targetRotation = Quaternion.Euler(-_lookRotation.x, _lookRotation.y, 0);
            Quaternion cameraRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cameraSmooth);

            player.Camera.transform.localRotation = cameraRotation;
        }

        
        private void OnLookAt(Vector2 obj)
        {
            if (player.IsDontAction == false || (IsComputerView == true && _isDontLookAt == true))
                _lookInput = obj;
        }
        
        private void LookAround(bool obj)
        {
            if (IsComputerView == true)
                _isDontLookAt = obj;
            else
                _isDontLookAt = false;
        }

        private void OnMovement(Vector2 obj)
        {
            if(player.IsDontAction == false && IsComputerView == false)
                _moveInput = new Vector3(obj.x, 0, obj.y);
        }
    }
}