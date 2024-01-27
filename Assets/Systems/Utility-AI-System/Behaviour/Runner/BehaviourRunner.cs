using System.Collections.Generic;
using UnityEngine;

namespace UtilityAISystem.Behaviour.Runner
{
    internal class BehaviourRunner : MonoBehaviour, IBehaviourRunner
    {
        private IEnumerable<IEvaluableBehaviour> _behaviours;

        private void Awake()
        {
            _behaviours = GetComponentsInChildren<IEvaluableBehaviour>();
        }

        public void Run()
        {
            if (_behaviours.TryGetBest(out IEvaluableBehaviour bestBehaviour))
                bestBehaviour.Run();
        }
    }
}