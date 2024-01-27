using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityAISystem.Behaviour
{
    internal static class BehaviourExtensions
    {
        public static bool TryGetBest<TBehaviour>(this IEnumerable<TBehaviour> behaviours, out TBehaviour bestBehaviour)
            where TBehaviour : IEvaluableBehaviour
        {
            bestBehaviour = behaviours.FirstOrDefault();
            float bestScore = float.NegativeInfinity;

            foreach (var behaviour in behaviours)
            {
                float score = behaviour.GetScore();
                if (score > bestScore)
                {
                    bestScore = score;
                    bestBehaviour = behaviour;
                }
            }

            return behaviours.Any();
        }

        public static bool TryGetBest<TBehaviour>(this IEnumerable<TBehaviour> behaviours, out TBehaviour bestBehaviour, Func<float, float> selector)
            where TBehaviour : IEvaluableBehaviour
        {
            bestBehaviour = behaviours.FirstOrDefault();
            float bestScore = float.NegativeInfinity;

            foreach (var behaviour in behaviours)
            {
                float score = selector(behaviour.GetScore());
                if (score > bestScore)
                {
                    bestScore = score;
                    bestBehaviour = behaviour;
                }
            }

            return behaviours.Any();
        }
    }
}