using System.Collections;
using UnityEngine;

namespace AbilitySystem.Input.Service
{
    internal class TriggerInputService : MonoBehaviour, IAbilityInputService<Collider2D>
    {
        [SerializeField]
        [Min(0)]
        private int _colliderCacheLifetimeFrames = 5;

        private Collider2D _cachedCollider;
        private Coroutine _cacheDeletionCoroutine;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            _cachedCollider = collider;
            _ = TryStartCacheDeletionCoroutine()
                || (TryStopCacheDeletionCoroutine()
                    && TryStartCacheDeletionCoroutine());
        }

        private bool TryStartCacheDeletionCoroutine()
        {
            if (_cacheDeletionCoroutine != null)
                return false;

            _cacheDeletionCoroutine = StartCoroutine(CacheDeletionCoroutine());
            return true;
        }

        private bool TryStopCacheDeletionCoroutine()
        {
            if (_cacheDeletionCoroutine == null)
                return false;

            StopCoroutine(_cacheDeletionCoroutine);
            _cacheDeletionCoroutine = null;
            return true;
        }

        private IEnumerator CacheDeletionCoroutine()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
            for (int i = 0; i < _colliderCacheLifetimeFrames; i++)
                yield return waitForFixedUpdate;

            _cachedCollider = null;
            _cacheDeletionCoroutine = null;
        }

        public Collider2D GetInput() => _cachedCollider;
    }
}