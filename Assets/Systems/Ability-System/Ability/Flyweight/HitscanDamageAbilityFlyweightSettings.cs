using AbilitySystem.Input.Service;
using AbilitySystem.Status.Components;
using UnityEngine;

namespace AbilitySystem.Ability.Flyweight
{
    [CreateAssetMenu(fileName = "HitscanDamageAbilityFlyweightSettings", menuName = "Ability System/Ability Flyweight/Hitscan Damage Ability")]
    internal class HitscanDamageAbilityFlyweightSettings : AbilityFlyweightSettings
    {
        [SerializeField]
        [Min(0.0f)]
        private float _damage;

        [SerializeField]
        private float _range;

        [SerializeField]
        private LayerMask _layerMask;

        public override IAbility Create(IAbilityInputService abilityDataService)
        {
            return abilityDataService.TryGetInput(out Ray ray)
                   ? new RaycastedAbility<IDamageable>(_range,
                                                       ray.origin,
                                                       ray.direction,
                                                       _layerMask,
                                                       new DamageAbility(_damage))
                   : NullAbility.Instance;
        }
    }
}