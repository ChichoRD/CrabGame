using UnityEngine;
namespace MovementSystem.Performer
{
    internal class PlanarMovementPerformer : MonoBehaviour, IMovementPerformer<Vector2>
    {
        [SerializeField]
        private float _movementSpeed = 1.0f;
        public bool TryPerformMovement(Rigidbody2D rigidbody, Vector2 direction)
        {
            Vector2 actualspeed = rigidbody.velocity;
            Vector2 targetspeed = _movementSpeed * direction;
            Vector2 finalspeed = (targetspeed - actualspeed) * 0.5f;

            rigidbody.AddForce(finalspeed * rigidbody.mass / Time.fixedDeltaTime);
            return true;
        }



    }
}


