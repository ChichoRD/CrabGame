using UnityEngine;

namespace MovementSystem.Performer
{
    public interface IMovementPerformer
    {
        bool TryPerformMovement(Rigidbody2D rigidbody);
    }
}