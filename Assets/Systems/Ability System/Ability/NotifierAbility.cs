using System;

namespace AbilitySystem.Ability
{
    internal struct NotifierAbility : IAbility
    {
        private readonly IAbility _ability;
        public event Action ExecutedSuccessfully;

        public NotifierAbility(IAbility ability, Action onExecutedSuccessfully)
        {
            _ability = ability;
            ExecutedSuccessfully = onExecutedSuccessfully;
        }

        public NotifierAbility(IAbility ability)
        {
            _ability = ability;
            ExecutedSuccessfully = () => { };
        }

        public readonly bool Execute()
        {
            bool success = _ability.Execute();
            if (success)
                ExecutedSuccessfully?.Invoke();

            return success;
        }
    }
}