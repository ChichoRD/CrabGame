using UnityEngine;
using UnityEngine.Events;

namespace AbilitySystem.Status.Components
{
    internal class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private float _initialHealth;
        [SerializeField]
        private bool _setInitialHealthOnStart = true;

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

        private void Start()
        {
            if (_setInitialHealthOnStart)
                CurrentHealth = _initialHealth;
        }

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