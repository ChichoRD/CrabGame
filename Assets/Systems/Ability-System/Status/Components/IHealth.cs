using UnityEngine.Events;

namespace AbilitySystem.Status.Components
{
    public interface IHealth : IDamageable, IHealable
    {
        float CurrentHealth { get; set; }
        UnityEvent<float> HealthSet { get; }
    }
}