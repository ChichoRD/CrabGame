using UnityEngine;
using UnityEngine.Events;

namespace AbilitySystem.Ability.Flyweight.Listener
{
    internal class AbilityFlyweightListener : MonoBehaviour
    {
        [SerializeField]
        private NotifierAbilityFlyweightSettings _abilityFlyweight;

        [field: SerializeField]
        public UnityEvent ExecutedSuccessfully { get; private set; }

        private void Awake()
        {
            _abilityFlyweight.ExecutedSuccessfully.AddListener(ExecutedSuccessfully.Invoke);
        }

        private void OnDestroy()
        {
            _abilityFlyweight.ExecutedSuccessfully.RemoveListener(ExecutedSuccessfully.Invoke);
        }
    }
}