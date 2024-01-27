using UnityEngine;
using UtilityAISystem.Behaviour.Runner;

public class PeriodicBehaviourRunner : MonoBehaviour
{
    private IBehaviourRunner _behaviourRunner;

    private void Awake()
    {
        _behaviourRunner = GetComponent<IBehaviourRunner>();
    }

    private void FixedUpdate()
    {
        _behaviourRunner.Run();
    }
}
