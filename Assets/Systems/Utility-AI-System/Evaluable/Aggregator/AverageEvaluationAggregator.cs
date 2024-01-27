using System.Collections.Generic;
using System.Linq;

namespace UtilityAISystem.Evaluable.Aggregator
{
    internal class AverageEvaluationAggregator : IEvaluationAggregator
    {
        public float Aggregate(IEnumerable<float> values) => values.Average();
    }
}