using RecipeSystem.Recipe.Ability.Test;
using UnityEngine;

namespace RecipeSystem.Recipe.Ability.Flyweight.Test
{
    [CreateAssetMenu(fileName = "TestAbilityRecipeFlyweightSettings", menuName = "Recipe System/Test Ability Recipe Flyweight Settings")]
    public class TestAbilityRecipeFlyweightSettings : AbilityRecipeFlyeightSettings
    {
        [SerializeField]
        private string _debugMessage;
        public override IAbilityRecipe Create() => new TestAbilityRecipe(_debugMessage);
    }
}