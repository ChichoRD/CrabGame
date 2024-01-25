using AbilitySystem.Ability;
using AbilitySystem.Status.Components;
using UnityEngine;

namespace AbilitySystem.Status.Handler
{
    internal class HealthAbilityHandler : MonoBehaviour,
        IAbilityHandler<IAbility<IDamageable>>,
        IAbilityHandler<IAbility<IHealable>>
    {
        private IHealth _health;

        private void Awake()
        {
            _health = GetComponentInChildren<IHealth>();
        }

        public bool Accept(IAbility<IDamageable> ability) =>
            ability.Execute(_health);

        public bool Accept(IAbility<IHealable> ability) =>
            ability.Execute(_health);
    }
}