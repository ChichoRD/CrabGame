using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UtilityAISystem.Evaluable.Aggregator
{
    internal class EvaluationAggregator : MonoBehaviour, IEvaluationAggregator, IEvaluable
    {
        [SerializeField]
        private AggregationType _aggregationType;

        private IEvaluationAggregator _aggregator;
        private IEnumerable<IEvaluable> _evaluables;

        private void Awake()
        {
            _aggregator = GetAggregator(_aggregationType);
            _evaluables = GetComponentsInChildren<IEvaluable>().Where(e => e != (IEvaluable)this);
        }

        public float Aggregate(IEnumerable<float> values) => _aggregator.Aggregate(values);
        public float GetScore() => Aggregate(_evaluables.Select(e => e.GetScore()));

        private IEvaluationAggregator GetAggregator(AggregationType aggregationType) => aggregationType switch
        {
           AggregationType.Product => new ProductEvaluationAggregator(),
            AggregationType.Sum => new SumEvaluationAggregator(),
            AggregationType.Min => new MinEvaluationAggregator(),
            AggregationType.Max => new MaxEvaluationAggregator(),
            AggregationType.Average => new AverageEvaluationAggregator(),
            _ => throw new ArgumentOutOfRangeException(nameof(aggregationType), aggregationType, null)
        };

        [Serializable]
        private enum AggregationType
        {
            Product,
            Sum,
            Min,
            Max,
            Average,
        }
    }
}