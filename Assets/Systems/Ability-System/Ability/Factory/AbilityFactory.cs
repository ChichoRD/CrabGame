using AbilitySystem.Ability.Flyweight;
using AbilitySystem.Input.Service;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem.Ability.Factory
{
    internal class AbilityFactory : MonoBehaviour, IAbilityFactory, IAbilityInputService
    {
        [SerializeField]
        private AbilityFlyweightSettings[] _abilityFlyweightSettings;

        private readonly Dictionary<Type, object> _abilityInputServices = new Dictionary<Type, object>();

        public IEnumerable<TAbility> GetAbilities<TAbility>() where TAbility : IAbility
        {
            foreach (var abilityFlyweightSettings in _abilityFlyweightSettings)
            {
                IAbility ability = abilityFlyweightSettings.Create(this);

                if (ability is TAbility typedAbility)
                    yield return typedAbility;
            }
        }

        public bool TryGetInput<TInput>(out TInput input)
        {
            input = default;
            bool success = TryGetInputServiceFromCached(out IAbilityInputService<TInput> inputService)
                           || (TryGetInputServiceFromChildren(out inputService)
                               && _abilityInputServices.TryAdd(typeof(TInput), inputService));
            if (success)
                input = inputService.GetInput();

            return success;
        }

        private bool TryGetInputServiceFromCached<TInput>(out IAbilityInputService<TInput> abilityInputService)
        {
            abilityInputService = default;
            bool success = _abilityInputServices.TryGetValue(typeof(TInput), out object value);

            if (success)
                abilityInputService = (IAbilityInputService<TInput>)value;

            return success;
        }

        private bool TryGetInputServiceFromChildren<TInput>(out IAbilityInputService<TInput> abilityInputService)
        {
            abilityInputService = GetComponentInChildren<IAbilityInputService<TInput>>();
            return abilityInputService != null;
        }
    }
}
