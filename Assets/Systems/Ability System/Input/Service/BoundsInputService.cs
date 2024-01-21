using UnityEngine;

namespace AbilitySystem.Input.Service
{
    internal class BoundsInputService : MonoBehaviour, IAbilityInputService<Bounds>
    {
        [SerializeField]
        private Transform _boundsOriginTransform;

        [SerializeField]
        private Vector3 _size;

        public Bounds GetInput()
        {
            return new Bounds(_boundsOriginTransform.position, _size);
        }
    }
}