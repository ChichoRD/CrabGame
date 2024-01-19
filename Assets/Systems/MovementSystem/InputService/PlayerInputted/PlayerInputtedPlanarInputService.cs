using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementSystem.InputService.PlayerInputted
{
    internal class PlayerInputtedPlanarInputService : MonoBehaviour, IInputService<Vector2>
    {
        [SerializeField] private InputActionReference _planarMovementActionReference;
        public Vector2 GetInput()
        {
            return _planarMovementActionReference.action.ReadValue<Vector2>();
        }


        private void OnEnable()
        {
            _planarMovementActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _planarMovementActionReference.action.Disable();
        }


    }
}