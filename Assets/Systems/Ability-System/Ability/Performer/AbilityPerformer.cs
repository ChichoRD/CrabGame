using AbilitySystem.Ability.Factory;
using UnityEngine;
using UnityEngine.Events;

namespace AbilitySystem.Ability.Performer
{
    internal class AbilityPerformer : MonoBehaviour, IAbilityPerformer //TODO - Indirection
    {
        private IAbilityFactory _abilityFactory;

        [field: SerializeField]
        public UnityEvent<IAbility> AbilityPerformed { get; private set; }

        [field: SerializeField]
        public UnityEvent<IAbility> AbilityFailed { get; private set; }

        private void Awake()
        {
            _abilityFactory = GetComponentInChildren<IAbilityFactory>();
        }

        public bool TryExecute()
        {
            bool success = true;

            foreach (var ability in _abilityFactory.GetAbilities<IAbility>())
            {
                bool abilitySuccess = ability.Execute();
                success &= abilitySuccess;

                if (abilitySuccess)
                    AbilityPerformed?.Invoke(ability);
                else
                    AbilityFailed?.Invoke(ability);
            }

            return success;
        }
    }
}