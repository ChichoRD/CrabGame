namespace AbilitySystem.Status.Components
{
    public interface IDamageable
    {
        bool TryTake(float damage);
    }
}