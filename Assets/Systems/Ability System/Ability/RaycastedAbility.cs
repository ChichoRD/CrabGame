using AbilitySystem.Status.Handler;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem.Ability
{
    internal readonly struct RaycastedAbility<TStatusComponent> : IAbility
    {
        private readonly float _range;
        private readonly Vector2 _origin;
        private readonly Vector2 _direction;
        private readonly LayerMask _layerMask;

        private readonly IAbility<TStatusComponent> _ability;

        public RaycastedAbility(float range, Vector2 origin, Vector2 direction, LayerMask layerMask, IAbility<TStatusComponent> ability)
        {
            _range = range;
            _direction = direction;
            _origin = origin;
            _layerMask = layerMask;
            _ability = ability;
        }

        public bool Execute()
        {
            bool success = false;

            foreach (var handler in GetAbilityHandlers<IAbility<TStatusComponent>>())
                success |= handler.Accept(_ability);

            return success;
        }

        public IEnumerable<IAbilityHandler<TAbility>> GetAbilityHandlers<TAbility>()
        {
            foreach (var hit in Physics2D.RaycastAll(_origin, _direction, _range, _layerMask))
                if (TryGetComponentInChildren(hit.collider, out IAbilityHandler<TAbility> handler))
                    yield return handler;

            static bool TryGetComponentInChildren<T>(Component component, out T t)
            {
                t = component.GetComponentInChildren<T>();
                return t != null;
            }
        }
    }
}
