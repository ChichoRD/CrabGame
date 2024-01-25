using RecipeSystem.Ingredient;
using RecipeSystem.Recipe.Ingredient;

namespace RecipeSystem.Recipe.Ability
{
    internal readonly struct IngredientAbilityRecipe : IIngredientRecipe, IAbilityRecipe
    {
        private readonly IIngredientRecipe _ingredientRecipe;
        private readonly IAbilityRecipe _abilityRecipe;

        public IngredientAbilityRecipe(IIngredientRecipe ingredientRecipe, IAbilityRecipe abilityRecipe)
        {
            _ingredientRecipe = ingredientRecipe;
            _abilityRecipe = abilityRecipe;
        }

        public void Execute() => _abilityRecipe.Execute();
        public bool RegisterIngredient(IngredientType ingredient) => _ingredientRecipe.RegisterIngredient(ingredient);
    }
}
