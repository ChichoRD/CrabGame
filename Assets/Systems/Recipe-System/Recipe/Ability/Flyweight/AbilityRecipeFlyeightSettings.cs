using UnityEngine;

namespace RecipeSystem.Recipe.Ability.Flyweight
{
    public abstract class AbilityRecipeFlyeightSettings : ScriptableObject
    {
        public abstract IAbilityRecipe Create();
    }
}