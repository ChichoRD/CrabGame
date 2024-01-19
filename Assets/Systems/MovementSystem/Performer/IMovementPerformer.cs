using UnityEngine;

namespace MovementSystem.Performer
{
    public interface IMovementPerformer<in TInput>
    {
        bool TryPerformMovement(Rigidbody2D rigidbody, TInput input);
    }
}