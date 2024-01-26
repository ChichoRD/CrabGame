using UnityEngine;

namespace AbilitySystem.Status.Components.Test
{
    internal class HealthNotifier : MonoBehaviour
    {
        private IHealth _health;

        private void Awake()
        {
            _health = GetComponent<IHealth>();
        }

        private void Start()
        {
            _health.HealthSet.AddListener(OnHealthSet);
        }

        private void OnDestroy()
        {
            _health.HealthSet.RemoveListener(OnHealthSet);
        }

        private void OnHealthSet(float health)
        {
            Debug.Log($"Health set to {health}");
        }
    }
}
