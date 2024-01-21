using AbilitySystem.Input.Service;
using UnityEngine;
using UnityEngine.Events;

namespace AbilitySystem.Ability.Flyweight
{
    [CreateAssetMenu(fileName = "NotifierAbilityFlyweightSettings", menuName = "Ability System/Ability Flyweight/Notifier Ability")]
    internal class NotifierAbilityFlyweightSettings : AbilityFlyweightSettings
    {
        [SerializeField]
        private AbilityFlyweightSettings _flyweightSettings;

        [field: SerializeField]
        public UnityEvent ExecutedSuccessfully { get; private set; }

        public override IAbility Create(IAbilityInputService abilityDataService)
        {
            return new NotifierAbility(_flyweightSettings.Create(abilityDataService), ExecutedSuccessfully.Invoke);
        }
    }
}