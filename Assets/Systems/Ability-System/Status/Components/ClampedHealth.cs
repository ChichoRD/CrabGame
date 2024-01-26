using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace AbilitySystem.Status.Components
{
    internal class ClampedHealth : MonoBehaviour, IHealth
    {
        private IHealth _health;

        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        private float _minHealth;

        [field: SerializeField]
        public UnityEvent<float> HealthWentUnderMin { get; private set; }

        [field: SerializeField]
        public UnityEvent<float> HealthWentOverMax { get; private set; }

        public UnityEvent<float> HealthSet => _health.HealthSet;
        public float CurrentHealth
        { 
            get => _health.CurrentHealth;
            set
            {
                if (value < _minHealth)
                {
                    HealthWentUnderMin?.Invoke(value);
                }
                else if (value > _maxHealth)
                {
                    HealthWentOverMax?.Invoke(value);
                }

                _health.CurrentHealth = Mathf.Clamp(value, _minHealth, _maxHealth);
            }
        }

        private void Awake()
        {
            _health = GetComponentsInChildren<IHealth>().FirstOrDefault(h => h != (IHealth)this);
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