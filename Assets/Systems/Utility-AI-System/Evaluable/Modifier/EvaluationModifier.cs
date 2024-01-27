using System.Linq;
using UnityEngine;

namespace UtilityAISystem.Evaluable.Modifier
{
    internal class EvaluationModifier : MonoBehaviour, IEvaluationModifier, IEvaluable
    {
        [SerializeField]
        private AnimationCurve _curve;

        private IEvaluationModifier _modifier;
        private IEvaluable _evaluable;

        private void Awake()
        {
            _modifier = new CurveEvaluationModifier(_curve);
            _evaluable = GetComponentsInChildren<IEvaluable>().FirstOrDefault(e => e != (IEvaluable)this);
        }

        public float Transform(float value) => _modifier.Transform(value);
        public float GetScore() => Transform(_evaluable.GetScore());
    }
}