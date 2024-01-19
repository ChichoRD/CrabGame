using InputBox.Readable;
using MovementSystem.InputService;
using MovementSystem.Performer;
using System.Threading.Tasks;
using UnityEngine;

namespace MovementSystem.Applier
{
    internal class PlanarMovementApplier : MonoBehaviour//, IMovementApplier
    {
        //private IInputService _inputService;
        //private IInputReadable<Vector2> _inputReadable;
        //private IMovementPerformer<Vector2> _movementPerformer;

        //private void Awake()
        //{
        //    _inputService = GetComponentInChildren<IInputService>();
        //    _movementPerformer = GetComponentInChildren<IMovementPerformer<Vector2>>();

        //    _inputService.TryGet(out _inputReadable);
        //}

        //public Task<bool> TryApplyMovement(Rigidbody2D rigidbody) =>
        //    Task.FromResult(_movementPerformer.TryPerformMovement(rigidbody, _inputReadable.Get()));
    }
}