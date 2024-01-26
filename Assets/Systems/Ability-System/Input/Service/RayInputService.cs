using UnityEngine;

namespace AbilitySystem.Input.Service
{
    internal class RayInputService : MonoBehaviour, IAbilityInputService<Ray>
    {
        [SerializeField]
        private Transform _rayOriginTransform;

        private IAbilityInputService<Vector2> _abilityInputService;

        private void Awake()
        {
            _abilityInputService = GetComponentInChildren<IAbilityInputService<Vector2>>();
        }

        public Ray GetInput()
        {
            return new Ray(_rayOriginTransform.position, _abilityInputService.GetInput());
        }

        private void OnDrawGizmosSelected()
        {
            if (_abilityInputService == null)
                return;

            Ray ray = GetInput();
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction);
        }
    }
}