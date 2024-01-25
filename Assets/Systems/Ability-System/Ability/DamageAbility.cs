using AbilitySystem.Status.Components;

namespace AbilitySystem.Ability
{
    internal readonly struct DamageAbility : IAbility<IDamageable>
    {
        private readonly float _damage;

        public DamageAbility(float damage)
        {
            _damage = damage;
        }

        public bool Execute(IDamageable statusComponent)
        {
            return statusComponent.TryTake(_damage);
        }
    }
}
