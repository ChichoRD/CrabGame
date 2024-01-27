using AbilitySystem.Status.Handler;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem.Ability
{
    internal readonly struct TriggerAbility<TStatusComponent> : IAbility
    {
        private readonly Collider2D _collider;
        private readonly LayerMask _layerMask;

        private readonly IAbility<TStatusComponent> _ability;

        public TriggerAbility(Collider2D collider, LayerMask layerMask, IAbility<TStatusComponent> ability)
        {
            _collider = collider;
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
            if (((_layerMask & (1 << _collider.gameObject.layer)) != 0)
                && TryGetComponentInChildren(_collider, out IAbilityHandler<TAbility> handler))
                yield return handler;

            static bool TryGetComponentInChildren<T>(Component component, out T t)
            {
                t = component.GetComponentInChildren<T>();
                return t != null;
            }
        }
    }
}
