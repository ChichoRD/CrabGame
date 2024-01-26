namespace AbilitySystem.Status.Components
{
    public interface IHealable
    {
        bool TryHeal(float heal);
    }
}