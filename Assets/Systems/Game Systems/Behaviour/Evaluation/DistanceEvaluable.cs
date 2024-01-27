using UnityEngine;
using UtilityAISystem.Evaluable;

namespace GameSystems.Behaviour.Evaluation
{
    internal class DistanceEvaluable : MonoBehaviour, IEvaluable
    {
        [field: SerializeField]
        public Transform Target { private get; set; }

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private bool _squared;

        [SerializeField]
        private bool _inverse;

        [SerializeField]
        private bool _negate;

        public float GetScore()
        {
            float distance = _squared
                             ? Vector3.SqrMagnitude(_transform.position - Target.position)
                             : Vector3.Distance(_transform.position, Target.position);

            return _inverse
                   ? _negate
                     ? GetNegated(GetInverse(distance))
                     : GetInverse(distance)
                   : distance;

            float GetInverse(float value) => 1.0f / value;

            float GetNegated(float value) => 1.0f - value;
        }
    }
}
