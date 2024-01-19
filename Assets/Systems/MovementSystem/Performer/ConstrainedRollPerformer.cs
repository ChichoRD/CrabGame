using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace MovementSystem.Performer
{
    internal class ConstrainedRollPerformer : MonoBehaviour, IMovementPerformer<Vector2>
    {
        private IMovementPerformer<Vector2> _rollPerformer;
        [SerializeField] private float _rollCoolDown;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        
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
            _rollPerformer = GetComponentsInChildren<IMovementPerformer<Vector2>>()
                .FirstOrDefault(p => p != (IMovementPerformer<Vector2>)this);
        }
    }
}


