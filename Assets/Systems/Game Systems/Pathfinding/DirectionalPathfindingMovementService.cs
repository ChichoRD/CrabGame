using UnityEngine;

namespace GameSystems.Pathfinding
{
    internal class DirectionalPathfindingMovementService : MonoBehaviour, IPathfindingMovementService
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private Transform _transform;

        public Vector2 GetMovementDirection() => (_target.position - _transform.position).normalized;
    }
}
