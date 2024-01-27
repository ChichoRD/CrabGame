using UnityEngine;

namespace UtilityAISystem.Evaluable.Source
{
    internal class ConstantEvaluable : MonoBehaviour, IEvaluable
    {
        [SerializeField]
        private float _value;

        public float GetScore() => _value;
    }
}