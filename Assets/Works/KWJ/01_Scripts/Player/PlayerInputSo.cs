using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Works.KWJ._01_Scripts
{
    [CreateAssetMenu(fileName = "PlayerInputSo", menuName = "SO/PlayerInputSo", order = 0)]
    public class PlayerInputSo : ScriptableObject, InputSystem_Actions.IPlayerActions
    {
        private InputSystem_Actions _inputSystem;
    
        public Action<Vector2> OnMoveAction;
        public Action<Vector2> AtLootAction;
        public Action<bool> OnLookAroundAction;
        public Action OnInteractionAction;
    
        private void OnEnable()
        {
            if (_inputSystem == null)
            {
                _inputSystem = new InputSystem_Actions();
                _inputSystem.Player.SetCallbacks(this);
            }
        
            _inputSystem.Player.Enable();
        }
        
        private void OnDisable()
        {
            _inputSystem.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 move = context.ReadValue<Vector2>();
            OnMoveAction?.Invoke(move);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            Vector2 lookat = context.ReadValue<Vector2>();
            AtLootAction?.Invoke(lookat);
        }
        
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed == true)
                OnInteractionAction?.Invoke();
        }

        public void OnLookAround(InputAction.CallbackContext context)
        {
            if (context.started == true)
                OnLookAroundAction?.Invoke(true);
            else if (context.canceled == true)
                OnLookAroundAction?.Invoke(false);
        }
    }
}