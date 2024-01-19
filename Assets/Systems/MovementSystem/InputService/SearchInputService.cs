using InputBox.Readable;
using UnityEngine;

namespace MovementSystem.InputService
{
    internal class SearchInputService : MonoBehaviour, IInputService
    {
        [SerializeField]
        private GameObject _inputReadableRoot;

        public bool TryGet<TInput>(out IInputReadable<TInput> inputReadable)
        {
            inputReadable = _inputReadableRoot.GetComponentInChildren<IInputReadable<TInput>>();
            return inputReadable != null;
        }
    }
}