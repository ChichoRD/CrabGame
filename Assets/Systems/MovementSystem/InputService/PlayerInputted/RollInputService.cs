using System.Linq;
using UnityEngine;

namespace MovementSystem.InputService
{
    internal class RollInputService : MonoBehaviour, IInputService<Vector2>
    {
        private IInputService<Vector2> _playerInputted;

        private Vector2 _prevNotZeroInput = Vector2.right;

        public Vector2 GetInput()
        {
            Vector2 vectorInput = _playerInputted.GetInput();
            if (vectorInput != Vector2.zero ) 
            {
                _prevNotZeroInput = vectorInput;
                return vectorInput;
            }
            else return _prevNotZeroInput;
        }

        private void Awake()
        {
            IInputService<Vector2>[] inputServices = GetComponentsInChildren<IInputService<Vector2>>();
            _playerInputted = inputServices.FirstOrDefault(NotThisElement);
        }

        private bool NotThisElement(IInputService<Vector2> element)
        {
            return (element != (IInputService<Vector2>)this);
        }







    }

    
}

