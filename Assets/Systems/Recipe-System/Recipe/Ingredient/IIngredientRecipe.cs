using RecipeSystem.Ingredient;

namespace RecipeSystem.Recipe.Ingredient
{
    public interface IIngredientRecipe
    {
        bool RegisterIngredient(IngredientType ingredient);
    }
}