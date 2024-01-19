using UnityEngine;

namespace MovementSystem.Performer
{
    internal class RollPerformer : MonoBehaviour, IMovementPerformer<Vector2>
    {
        
        [SerializeField] private float _rollDuration, _speedAugment;
        
        public bool TryPerformMovement(Rigidbody2D rigidbody, Vector2 direction)
        {
            //m * dv = F * dt
            rigidbody.AddForce((_speedAugment * rigidbody.mass * direction) / _rollDuration); 
            return true;
        }
    }
}


