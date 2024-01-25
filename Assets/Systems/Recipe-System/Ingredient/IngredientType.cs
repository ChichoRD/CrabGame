using System;

namespace RecipeSystem.Ingredient
{
    [Flags]
    public enum IngredientType
    {
        Rice = 1 << 0,
        Nori = 1 << 1,
        Shrimp = 1 << 2,
        Soy = 1 << 3,
    }
}