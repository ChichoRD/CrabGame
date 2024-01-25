using AbilitySystem.Ability.Performer;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AbilitySystem.Ability.Perfomer.Test
{
    internal class PlayerInputtedAbilityPerformer : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _abilityActionReference;
        private IAbilityPerformer _abilityPerformer;

        private void Awake()
        {
            _abilityPerformer = GetComponent<IAbilityPerformer>();

            _abilityActionReference.action.performed += OnAbilityActionPerformed;
        }

        private void OnEnable()
        {
            _abilityActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _abilityActionReference.action.Disable();
        }

        private void OnAbilityActionPerformed(InputAction.CallbackContext obj)
        {
            _abilityPerformer.TryExecute();
        }
    }
}