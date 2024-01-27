using System.Collections.Generic;
using System.Linq;

namespace UtilityAISystem.Evaluable.Aggregator
{
    internal class ProductEvaluationAggregator : IEvaluationAggregator
    {
        public float Aggregate(IEnumerable<float> values) => values.Aggregate(1.0f, (acc, val) => acc * val);
    }
}