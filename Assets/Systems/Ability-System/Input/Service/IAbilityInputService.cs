namespace AbilitySystem.Input.Service
{
    public interface IAbilityInputService
    {
        bool TryGetInput<TInput>(out TInput input);
    }

    public interface IAbilityInputService<out TInput> : IAbilityInputService
    {
        bool IAbilityInputService.TryGetInput<UInput>(out UInput input)
        {
            input = default;
            if (GetInput() is UInput uInput)
            {
                input = uInput;
                return true;
            }

            return false;
        }

        TInput GetInput();
    }
}