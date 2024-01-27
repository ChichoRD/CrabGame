using RecipeSystem.Ingredient;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RecipeSystem.Recipe.Ingredient
{
    internal struct IngredientQuotaRecipe : IIngredientRecipe, IObservableIngredientRecipe
    {
        private readonly Dictionary<IngredientType, int> _totalQuota;
        private Dictionary<IngredientType, int> _currentQuota;

        public event Action QuotaReached;
        public event Action RecipeEvent
        {
            add { QuotaReached += value; }
            remove { QuotaReached -= value; }
        }

        public IngredientQuotaRecipe(Dictionary<IngredientType, int> totalQuota, Action onQuotaReached)
        {
            _totalQuota = totalQuota;
            _currentQuota = new Dictionary<IngredientType, int>(_totalQuota);

            QuotaReached = onQuotaReached;
        }

        public IngredientQuotaRecipe(Dictionary<IngredientType, int> totalQuota)
        {
            _totalQuota = totalQuota;
            _currentQuota = new Dictionary<IngredientType, int>(_totalQuota);

            QuotaReached = () => { };
        }

        public bool RegisterIngredient(IngredientType ingredient)
        {
            if (_currentQuota.Count == 0)
                _currentQuota = new Dictionary<IngredientType, int>(_totalQuota);

            if (ReduceQuota(_currentQuota, ingredient, 1) <= 0)
                _currentQuota.Remove(ingredient);

            if (_currentQuota.Count == 0)
                QuotaReached?.Invoke();

            Debug.Log(ToString());
            return true;
        }

        private static int ReduceQuota(Dictionary<IngredientType, int> quota, IngredientType ingredient, int amount)
        {
            int newQuota = -amount;
            if (quota.TryGetValue(ingredient, out var quotaAmount))
            {
                newQuota += quotaAmount;
                quota[ingredient] = newQuota;
            }

            return newQuota;
        }

        public override readonly string ToString()
        {
            string result = "Quota: ";
            foreach (var quota in _currentQuota)
                result += $"{quota.Key} {quota.Value} ";

            return result;
        }
    }
}
