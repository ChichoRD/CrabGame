using System.Linq;
using UnityEngine;
using UtilityAISystem.Evaluable;

namespace UtilityAISystem.Behaviour
{
    internal class EvaluableBehaviour : MonoBehaviour, IEvaluableBehaviour
    {
        private IBehaviour _behaviour;
        private IEvaluable _evaluable;

        private void Awake()
        {
            _behaviour = GetComponents<IBehaviour>().FirstOrDefault(b => b != (IBehaviour)this);
            _evaluable = GetComponents<IEvaluable>().FirstOrDefault(e => e != (IEvaluable)this);
        }

        public float GetScore() => _evaluable.GetScore();
        public void Run() => _behaviour.Run();
    }
}