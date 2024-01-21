using AbilitySystem.Status.Handler;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem.Ability
{
    internal readonly struct HitboxAbility<TStatusComponent> : IAbility
    {
        private readonly Bounds _bounds;
        private readonly LayerMask _layerMask;
        private readonly IAbility<TStatusComponent> _ability;

        public HitboxAbility(Bounds bounds, LayerMask layerMask, IAbility<TStatusComponent> ability)
        {
            _bounds = bounds;
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
            foreach (var hit in Physics2D.OverlapBoxAll(_bounds.center, _bounds.size, 0, _layerMask))
                if (TryGetComponentInChildren(hit, out IAbilityHandler<TAbility> handler))
                    yield return handler;

            static bool TryGetComponentInChildren<T>(Component component, out T t)
            {
                t = component.GetComponentInChildren<T>();
                return t != null;
            }
        }
    }
}
