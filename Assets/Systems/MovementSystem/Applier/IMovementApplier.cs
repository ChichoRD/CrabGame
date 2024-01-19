using System.Threading.Tasks;
using UnityEngine;

namespace MovementSystem.Applier
{
    public interface IMovementApplier
    {
        Task<bool> TryApplyMovement(Rigidbody2D rigidbody);
    }
}