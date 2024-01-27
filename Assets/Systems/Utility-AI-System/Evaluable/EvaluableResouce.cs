using UnityEngine;

namespace UtilityAISystem.Evaluable
{
    internal class EvaluableResouce : MonoBehaviour, IEvaluable
    {
        [SerializeField]
        private Object _evaluableObject;
        private IEvaluable _evaluable;

        private void Awake()
        {
            _evaluable = _evaluableObject as IEvaluable;
        }

        public float GetScore() => _evaluable.GetScore();
    }
}