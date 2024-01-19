using InputBox.Readable;
using InputBox.Writeable;
using UnityEngine;

namespace MovementSystem.InputService.PlayerInputted
{
    internal class TontoPlanarInputService : MonoBehaviour, IInputService
    {
        private IInputWriteable<Vector2> _inputWriteable;

        public bool TryGet<TInput>(out IInputReadable<TInput> inputReadable)
        {
            inputReadable = GetComponentInChildren<IInputReadable<TInput>>();
            return (inputReadable != null);
        }

        private void Update()
        {
            _inputWriteable.TrySet(Vector2.right);
        }

        private void Awake()
        {
            _inputWriteable = GetComponentInChildren<IInputWriteable<Vector2>>();
        }
    }
}