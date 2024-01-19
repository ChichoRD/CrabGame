using MovementSystem.Performer;
using System.Diagnostics;
using UnityEngine;

namespace MovementSystem.Performer
{
    internal class ConstrainedRollPerformer : MonoBehaviour, IMovementPerformer<Vector2>
    {
        private IMovementPerformer<Vector2> _rollPerformer;
        [SerializeField] private float _rollCoolDown;
        private Stopwatch _stopwatch = new Stopwatch();
        
        public bool TryPerformMovement(Rigidbody2D rigidbody, Vector2 input)
        {
            if (_stopwatch.Elapsed.TotalSeconds >= _rollCoolDown 
                && _rollPerformer.TryPerformMovement(rigidbody, input))
            {
                _stopwatch.Restart();
                return true;
            }
            else return false;
            
        }

        private void Awake()
        {
            _stopwatch.Start();

            IMovementPerformer<Vector2>[] performers = GetComponentsInChildren<IMovementPerformer<Vector2>>();

            int i = 0;
            bool performerFound = false;

            while (i < performers.Length && !performerFound) 
            {
                if (performers[i] != (IMovementPerformer<Vector2>)this)
                {
                    _rollPerformer = performers[i];
                    performerFound = true;
                }
            }
        }
    }
}


