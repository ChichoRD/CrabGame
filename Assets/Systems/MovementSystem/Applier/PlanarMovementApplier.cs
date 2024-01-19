using MovementSystem.InputService;
using MovementSystem.Performer;
using UnityEngine;

namespace MovementSystem.Applier
{
    internal class PlanarMovementApplier : MonoBehaviour, IMovementApplier
    {
        private IMovementPerformer<Vector2> _movementPerformer;
        private IInputService<Vector2> _inputService;

        public bool TryApplyMovement(Rigidbody2D rigidbody)
        {
            return _movementPerformer.TryPerformMovement(rigidbody, _inputService.GetInput()); 
        }

        private void Awake()
        {
            _movementPerformer = GetComponentInChildren<IMovementPerformer<Vector2>>();
            _inputService = GetComponentInChildren<IInputService<Vector2>>();
        }

         
    }
}