using System.Collections.Generic;

namespace AbilitySystem.Ability.Factory
{
    public interface IAbilityFactory
    {
        IEnumerable<TAbility> GetAbilities<TAbility>() where TAbility : IAbility;
    }
}