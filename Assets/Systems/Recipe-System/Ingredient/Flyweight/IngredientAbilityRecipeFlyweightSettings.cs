using RecipeSystem.Recipe.Ability;
using RecipeSystem.Recipe.Ability.Flyweight;
using RecipeSystem.Recipe.Ingredient;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecipeSystem.Ingredient.Flyweight
{
    [CreateAssetMenu(fileName = "IngredientAbilityRecipeFlyweightSettings", menuName = "Recipe System/Ingredient Ability Recipe Flyweight Settings")]
    internal class IngredientAbilityRecipeFlyweightSettings : IngredientRecipeFlyweightSettings
    {
        [SerializeField]
        private IngredientQuotaItem[] _ingredientQuotaItems;

        [SerializeField]
        private AbilityRecipeFlyeightSettings _abilityRecipeFlyweight;

        public override IIngredientRecipe Create() =>
            new IngredientQuotaRecipe(GetQuota(_ingredientQuotaItems), _abilityRecipeFlyweight.Create().Execute);

        [Serializable]
        private struct IngredientQuotaItem
        {
            [field: SerializeField]
            public IngredientType Ingredient { get; private set; }

            [field: SerializeField]
            public int Quota { get; private set; }

            public IngredientQuotaItem(IngredientType ingredient, int quota)
            {
                Ingredient = ingredient;
                Quota = quota;
            }
        }

        private static Dictionary<IngredientType, int> GetQuota(IEnumerable<IngredientQuotaItem> quotaItems)
        {
            var quota = new Dictionary<IngredientType, int>();
            foreach (var quotaItem in quotaItems)
                if (!quota.TryAdd(quotaItem.Ingredient, quotaItem.Quota))
                    quota[quotaItem.Ingredient] += quotaItem.Quota;

            return quota;
        }
    }
}