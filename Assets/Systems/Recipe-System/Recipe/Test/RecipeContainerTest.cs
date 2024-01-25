using RecipeSystem.Ingredient;
using UnityEngine;

namespace RecipeSystem.Recipe.Test
{
    internal class RecipeContainerTest : MonoBehaviour
    {
        [SerializeField]
        private RecipeContainer _recipeContainer;

        [SerializeField]
        private IngredientType _ingredientType;

        [ContextMenu(nameof(Test))]
        private void Test()
        {
            _recipeContainer.AccountForIngredient(_ingredientType);
        }
    }
}