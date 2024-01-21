using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilitySystem.Input.Service
{
    internal class PlayerInputtedAbilityInputService : MonoBehaviour, IAbilityInputService<Vector2>
    {
        [SerializeField]
        private InputActionReference _inputActionReference;

        private void OnEnable()
        {
            _inputActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _inputActionReference.action.Disable();
        }

        public Vector2 GetInput()
        {
            return _inputActionReference.action.ReadValue<Vector2>();
        }
    }
}