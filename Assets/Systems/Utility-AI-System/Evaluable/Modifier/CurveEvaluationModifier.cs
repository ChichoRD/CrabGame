using UnityEngine;

namespace UtilityAISystem.Evaluable.Modifier
{
    internal class CurveEvaluationModifier : IEvaluationModifier
    {
        private readonly AnimationCurve _curve;

        public CurveEvaluationModifier(AnimationCurve curve)
        {
            _curve = curve;
        }

        public float Transform(float value) => _curve.Evaluate(value);
    }
}