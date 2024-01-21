using AbilitySystem.Input.Service;
using AbilitySystem.Status.Components;
using UnityEngine;

namespace AbilitySystem.Ability.Flyweight
{
    [CreateAssetMenu(fileName = "HitboxDamageAbilityFlyweightSettings", menuName = "Ability System/Ability Flyweight/Hitbox Damage Ability")]
    internal class HitboxDamageAbilityFlyweightSettings : AbilityFlyweightSettings
    {
        [SerializeField]
        [Min(0.0f)]
        private float _damage;

        [SerializeField]
        private LayerMask _layerMask;

        public override IAbility Create(IAbilityInputService abilityDataService)
        {
            return abilityDataService.TryGetInput(out Bounds bounds)
                ? new HitboxAbility<IDamageable>(bounds, _layerMask, new DamageAbility(_damage))
                : NullAbility.Instance;
        }
    }
}