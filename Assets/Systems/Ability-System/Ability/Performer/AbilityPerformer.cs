using AbilitySystem.Ability.Factory;
using UnityEngine;

namespace AbilitySystem.Ability.Performer
{
    internal class AbilityPerformer : MonoBehaviour, IAbilityPerformer //TODO - Indirection
    {
        private IAbilityFactory _abilityFactory;

        private void Awake()
        {
            _abilityFactory = GetComponentInChildren<IAbilityFactory>();
        }

        public bool TryExecute()
        {
            bool success = true;

            foreach (var ability in _abilityFactory.GetAbilities<IAbility>())
                    success &= ability.Execute();

            return success;
        }
    }
}