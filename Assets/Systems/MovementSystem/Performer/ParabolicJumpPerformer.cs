using System.Collections;
using UnityEngine;

namespace MovementSystem.Performer
{
    internal class ParabolicJumpPerformer : MonoBehaviour, IMovementPerformer<Vector3>, IMovementPerformer<Vector2>
    {
        [SerializeField]
        [Min(0.0f)]
        private float _jumpDistance = 2.0f;

        [SerializeField]
        [Min(0.0f)]
        private float _jumpTime = 1.0f;

        [SerializeField]
        private Matrix4x4 _jumpTransformation = Matrix4x4.identity;

        private Coroutine _jumpCoroutine;

        public bool TryPerformMovement(Rigidbody2D rigidbody, Vector3 input) =>
            TryStartJumpCoroutine(rigidbody, input);

        public bool TryPerformMovement(Rigidbody2D rigidbody, Vector2 input) =>
            TryStartJumpCoroutine(
                rigidbody,
                GetVerticalVelocityIncrement() + GetHorizontalVelocityIncrement(new Vector3(input.x, 0.0f, input.y)));

        private bool TryStartJumpCoroutine(Rigidbody2D rigidbody, Vector3 jumpVelocityIncrement)
        {
            if (_jumpCoroutine != null)
                return false;

            _jumpCoroutine = StartCoroutine(JumpCoroutine(rigidbody, jumpVelocityIncrement));
            return true;
        }

        private bool TryStopJumpCoroutine()
        {
            if (_jumpCoroutine == null)
                return false;

            StopCoroutine(_jumpCoroutine);
            _jumpCoroutine = null;
            return true;
        }

        private IEnumerator JumpCoroutine(Rigidbody2D rigidbody, Vector3 jumpVelocityIncrement)
        {
            Vector3 transformedJumpVelocity = _jumpTransformation.MultiplyVector(jumpVelocityIncrement);
            Vector3 transformedJumpForce = transformedJumpVelocity * rigidbody.mass / Time.fixedDeltaTime;
            rigidbody.AddForce(transformedJumpForce, ForceMode2D.Force);

            Vector3 transformedGravity = _jumpTransformation.MultiplyVector(Physics2D.gravity);
            Vector3 transformedGravityForce = transformedGravity * rigidbody.mass;

            float velocityReductionTime = -Vector3.Dot(Physics2D.gravity, jumpVelocityIncrement * 2.0f) / Vector3.Dot(Physics2D.gravity, Physics2D.gravity);

            float deltaTime = Time.fixedDeltaTime;
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

            for (float t = 0.0f; t < velocityReductionTime; t += deltaTime)
            {
                rigidbody.AddForce(transformedGravityForce, ForceMode2D.Force);
                yield return waitForFixedUpdate;
            }

            _jumpCoroutine = null;
        }

        private Vector3 GetVerticalVelocityIncrement() => _jumpTime * 0.5f * -Physics2D.gravity;
        private Vector3 GetHorizontalVelocityIncrement(Vector3 direction) => (_jumpDistance / _jumpTime) * direction;
    }
}
