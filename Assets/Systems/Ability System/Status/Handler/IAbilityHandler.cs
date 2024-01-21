namespace AbilitySystem.Status.Handler
{
    public interface IAbilityHandler<in TAbility>
    {
        bool Accept(TAbility ability);
    }
}