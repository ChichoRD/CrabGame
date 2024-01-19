using UnityEngine;

namespace MovementSystem.InputService
{
    public interface IInputService<out TInput>
    {
        TInput GetInput();
    }
}