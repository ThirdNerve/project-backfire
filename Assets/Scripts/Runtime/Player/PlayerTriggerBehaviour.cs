using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerTriggerBehaviour : MonoBehaviour
    {
        private BoxCollider2D _reflectorCollider;
        private ReflectorTriggerBehaviour _reflector;
        private const int backtrackFrameCount = 3;

        private void Awake()
        {
            _reflectorCollider = GetComponentInChildren<BoxCollider2D>();
            _reflector = GetComponentInChildren<ReflectorTriggerBehaviour>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectile = other.GetComponent<ProjectileBehaviour>();
            if (projectile is null || projectile.IsReflected)
            {
                return;
            }

            if (IsInvalidCollision(projectile))
            {
                return;
            }

            Destroy(gameObject);
        }

        // Sometimes this triggers before the reflector triggers and we die. This is my way of trying to fix it :D
        private bool IsInvalidCollision(ProjectileBehaviour projectile)
        {
            if (!_reflector.gameObject.activeSelf)
            {
                return false;
            }

            var projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            var backTrackVector = -projectileRigidbody.velocity * backtrackFrameCount * Time.deltaTime;

            if (!IntersectOABB(projectileRigidbody.position, backTrackVector, _reflectorCollider))
            {
                return false;
            }

            _reflector.ReflectProjectile(projectile);
            return true;

        }

        private bool IntersectOABB (Vector2 origin, Vector2 vector, BoxCollider2D box)
        {
            var localOrigin = (Vector2) box.transform.InverseTransformPoint(origin) - box.offset;
            var localDirection = (Vector2) box.transform.InverseTransformDirection(vector) - box.offset;

            var ray = new Ray(localOrigin, localDirection);
            var bounds = new Bounds(Vector3.zero, box.size);

            return BoundsIntersectRay(bounds, ray, vector.sqrMagnitude);
        }

        private static bool BoundsIntersectRay(Bounds bounds, Ray ray, float squaredLength)
        {
            if (!bounds.IntersectRay(ray, out var distance))
            {
                return false;
            }
            
            return Mathf.Pow(distance, 2) <= squaredLength;
        }
    }
}
