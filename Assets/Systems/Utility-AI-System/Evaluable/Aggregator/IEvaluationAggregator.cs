using System.Collections.Generic;

namespace UtilityAISystem.Evaluable.Aggregator
{
    public interface IEvaluationAggregator
    {
        float Aggregate(IEnumerable<float> values);
    }
}