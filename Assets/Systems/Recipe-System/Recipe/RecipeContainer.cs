using RecipeSystem.Ingredient;
using RecipeSystem.Ingredient.Flyweight;
using RecipeSystem.Recipe.Ingredient;
using System.Collections.Generic;
using UnityEngine;

namespace RecipeSystem.Recipe
{
    internal class RecipeContainer : MonoBehaviour, IRecipeContainer
    {
        private List<IIngredientRecipe> _recipes;

        private void Awake()
        {
            _recipes = new List<IIngredientRecipe>();
        }

        public void AddRecipe(IIngredientRecipe recipe) => _recipes.Add(recipe);

        public void AddRecipeFrom(IngredientAbilityRecipeFlyweightSettings flyweightSettings) =>
            AddRecipe(flyweightSettings.Create());

        public bool AccountForIngredient(IngredientType ingredient)
        {
            bool success = true;
            foreach (var recipe in _recipes)
                success &= recipe.RegisterIngredient(ingredient);

            return success;
        }
    }
}