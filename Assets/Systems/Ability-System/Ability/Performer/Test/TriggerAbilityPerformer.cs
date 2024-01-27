using AbilitySystem.Ability.Performer;
using UnityEngine;

namespace AbilitySystem.Ability.Perfomer.Test
{
    internal class TriggerAbilityPerformer : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layerMask;

        private IAbilityPerformer _abilityPerformer;

        private void Awake()
        {
            _abilityPerformer = GetComponent<IAbilityPerformer>();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if ((_layerMask & (1 << collider.gameObject.layer)) != 0)
                _abilityPerformer.TryExecute();
        }
    }
}