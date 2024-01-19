using UnityEngine;

namespace MovementSystem.Applier
{
    internal class PeriodicMovementApplier : MonoBehaviour
    {
        private IMovementApplier _movementApplier;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _movementApplier = GetComponentInChildren<IMovementApplier>();
        }

        private void FixedUpdate()
        {
            _movementApplier.TryApplyMovement(_rigidbody);
        }
    }
}