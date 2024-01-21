using AbilitySystem.Input.Service;
using UnityEngine;

namespace AbilitySystem.Ability.Flyweight
{
    internal abstract class AbilityFlyweightSettings : ScriptableObject
    {
        public abstract IAbility Create(IAbilityInputService abilityDataService);

        protected readonly struct NullAbility : IAbility
        {
            private static readonly NullAbility _instance = new NullAbility();
            public readonly bool Execute() => false;
            public static NullAbility Instance => _instance;
        }
    }
}