using AbilitySystem.Input.Service;
using AbilitySystem.Status.Components;
using UnityEngine;

namespace AbilitySystem.Ability.Flyweight
{
    [CreateAssetMenu(fileName = "TriggerDamageAbilityFlyweightSettings", menuName = "Ability System/Ability Flyweight/Trigger Damage Ability")]
    internal class TriggerDamageAbilityFlyweightSettings : AbilityFlyweightSettings
    {
        [SerializeField]
        [Min(0.0f)]
        private float _damage;

        [SerializeField]
        private LayerMask _layerMask;

        public override IAbility Create(IAbilityInputService abilityDataService)
        {
            return (abilityDataService.TryGetInput(out Collider2D collider) && collider != null)
                ? new TriggerAbility<IDamageable>(collider, _layerMask, new DamageAbility(_damage))
                : NullAbility.Instance;
        }
    }
}