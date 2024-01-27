using MovementSystem.InputService;
using UnityEngine;

namespace GameSystems.Movement.Input
{
    internal class SettableMovementInputService : MonoBehaviour, IInputService<Vector2>
    {
        private Vector2 _movementInput;

        public void SetMovementInput(Vector2 movementInput) => _movementInput = movementInput;

        public Vector2 GetInput() => _movementInput;
    }
}