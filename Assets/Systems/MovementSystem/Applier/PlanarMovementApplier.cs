using InputBox.Readable;
using MovementSystem.InputService;
using MovementSystem.Performer;
using UnityEngine;

namespace MovementSystem.Applier
{
    internal class PlanarMovementApplier : MonoBehaviour, IMovementApplier
    {
        private IMovementPerformer<Vector2> _movementPerformer;
        private IInputReadable<Vector2> _input;
        private IInputService _inputService;

        public bool TryApplyMovement(Rigidbody2D rigidbody)
        {
            return _movementPerformer.TryPerformMovement(rigidbody, _input.Get()); 
        }

        private void Awake()
        {
            _movementPerformer = GetComponentInChildren<IMovementPerformer<Vector2>>();
            _inputService = GetComponentInChildren<IInputService>();
            _inputService.TryGet(out _input);
        }

         
    }
}