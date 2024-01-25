using RecipeSystem.Ingredient;

namespace RecipeSystem.Recipe
{
    public interface IRecipeContainer
    {
        bool AccountForIngredient(IngredientType ingredient);
    }
}