using UnityEngine;

namespace MovementSystem.InputService.PlayerInputted
{
    internal class TontoPlanarInputService : MonoBehaviour, IInputService<Vector2>
    {
        public Vector2 GetInput()
        {
            return Vector2.right;
        }

    }
}