using UnityEngine;
using UnityEngine.Events;

namespace AbilitySystem.Status.Components
{
    internal class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                HealthSet?.Invoke(_currentHealth);
            }
        }

        [field: SerializeField]
        public UnityEvent<float> HealthSet { get; private set; }

        public bool TryHeal(float heal)
        {
            CurrentHealth += heal;
            return true;
        }

        public bool TryTake(float damage)
        {
            CurrentHealth -= damage;
            return true;
        }
    }
}