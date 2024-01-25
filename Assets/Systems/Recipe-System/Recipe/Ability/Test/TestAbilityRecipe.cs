using UnityEngine;

namespace RecipeSystem.Recipe.Ability.Test
{
    internal readonly struct TestAbilityRecipe : IAbilityRecipe
    {
        private readonly string _message;

        public TestAbilityRecipe(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Debug.Log(_message);
        }
    }
}