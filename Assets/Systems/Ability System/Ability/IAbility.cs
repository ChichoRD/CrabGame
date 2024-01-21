using AbilitySystem.Status.Handler;
using System.Collections.Generic;

namespace AbilitySystem.Ability
{
    public interface IAbility
    {
        bool Execute();
    }

    public interface IAbility<in TStatusComponent>
    {
        bool Execute(TStatusComponent statusComponent);
    }
}
