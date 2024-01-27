using GameSystems.Movement.Input;
using GameSystems.Pathfinding;
using MovementSystem.Applier;
using UnityEngine;
using UtilityAISystem.Behaviour;

namespace GameSystems.Behaviour
{
    internal class MovementApplierBehaviour : MonoBehaviour, IBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private SettableMovementInputService _movementInputService;

        private IPathfindingMovementService _pathfindingService;
        private IMovementApplier _movementApplier;

        private void Awake()
        {
            _pathfindingService = GetComponentInChildren<IPathfindingMovementService>();
            _movementApplier = GetComponentInChildren<IMovementApplier>();     
        }

        public void Run()
        {
            _movementInputService.SetMovementInput(_pathfindingService.GetMovementDirection());
            _movementApplier.TryApplyMovement(_rigidbody);
        }
    }
}