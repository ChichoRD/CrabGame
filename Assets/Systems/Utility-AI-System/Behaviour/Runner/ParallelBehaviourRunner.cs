using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UtilityAISystem.Behaviour.Runner
{
    internal class ParallelBehaviourRunner : MonoBehaviour, IBehaviourRunner
    {
        private IEnumerable<IBehaviourRunner> _behaviourRunners;

        private void Awake()
        {
            _behaviourRunners = GetComponentsInChildren<IBehaviourRunner>().Where(b => b != (IBehaviourRunner)this);
        }

        public void Run()
        {
            foreach (var behaviourRunner in _behaviourRunners)
                behaviourRunner.Run();
        }
    }
}