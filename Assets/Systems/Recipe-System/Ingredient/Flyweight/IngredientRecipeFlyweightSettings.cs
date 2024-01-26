using RecipeSystem.Recipe.Ingredient;
using UnityEngine;

namespace RecipeSystem.Ingredient.Flyweight
{
    public abstract class IngredientRecipeFlyweightSettings : ScriptableObject
    {
        public abstract IIngredientRecipe Create();
    }
}