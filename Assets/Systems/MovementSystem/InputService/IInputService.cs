using InputBox.Readable;

namespace MovementSystem.InputService
{
    public interface IInputService
    {
        bool TryGet<TInput>(out IInputReadable<TInput> inputReadable);
    }
}