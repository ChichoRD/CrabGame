using System.Threading.Tasks;
using UnityEngine;

namespace MovementSystem.Applier
{
    public interface IMovementApplier
    {
        bool TryApplyMovement(Rigidbody2D rigidbody);
    }
}