using InputBox.Readable;
using InputBox.Writeable;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementSystem.InputService.PlayerInputted
{
    internal class PlayerInputtedPlanarInputService : MonoBehaviour//, IInputService
    {
        //[SerializeField]
        //private InputActionReference _planarMovementActionReference;
        //private IInputWriteable<Vector2> _planarMovementInputWriteable;

        //private IInputService _inputService;

        //private void Awake()
        //{
        //    _inputService = GetComponentsInChildren<IInputService>().FirstOrDefault(i => i != (IInputService)this);
        //    _planarMovementInputWriteable = GetComponentInChildren<IInputWriteable<Vector2>>();
        //}

        //private void Update()
        //{
        //    _planarMovementInputWriteable.TrySet(_planarMovementActionReference.action.ReadValue<Vector2>());
        //}

        //public bool TryGet<TInput>(out IInputReadable<TInput> inputReadable) => _inputService.TryGet(out inputReadable);
    }
}