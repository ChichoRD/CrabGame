using System;

namespace RecipeSystem.Recipe.Ingredient
{
    public interface IObservableIngredientRecipe
    {
        event Action RecipeEvent;
    }
}
