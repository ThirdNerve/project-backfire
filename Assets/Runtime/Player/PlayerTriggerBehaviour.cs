using Com.ThirdNerve.Backfire.Runtime.Agent;
using Com.ThirdNerve.Backfire.Runtime.Health;
using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    [RequireComponent(typeof(HealthBehaviour))]
    [RequireComponent(typeof(AgentBehaviour))]
    public class PlayerTriggerBehaviour : MonoBehaviour
    {
        private BoxCollider2D? _reflectorCollider;
        private ReflectorTriggerBehaviour? _reflector;
        private const int BacktrackFrameCount = 3;
        private HealthBehaviour? _healthBehaviour;
        private AgentBehaviour? _agentBehaviour;

        private void Awake()
        {
            _agentBehaviour = GetComponent<AgentBehaviour>();
            _healthBehaviour = GetComponent<HealthBehaviour>();
            _reflectorCollider = GetComponentInChildren<BoxCollider2D>();
            _reflector = GetComponentInChildren<ReflectorTriggerBehaviour>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectileBehaviour = other.GetComponent<ProjectileBehaviour>();
            if (projectileBehaviour is null || projectileBehaviour.Owner.Team == _agentBehaviour.Team)
            {
                return;
            }

            if (IsInvalidCollision(projectileBehaviour))
            {
                return;
            }

            _healthBehaviour.Damage(projectileBehaviour.Damage, projectileBehaviour.Owner);
            Destroy(other.gameObject);
        }

        // Sometimes this triggers before the reflector triggers and we die. This is my way of trying to fix it :D
        private bool IsInvalidCollision(ProjectileBehaviour projectile)
        {
            if (!_reflector.gameObject.activeSelf)
            {
                return false;
            }

            var projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            var backTrackVector = -projectileRigidbody.velocity * BacktrackFrameCount * Time.deltaTime;

            if (!IntersectOABB(projectileRigidbody.position, backTrackVector, _reflectorCollider))
            {
                return false;
            }

            _reflector.ReflectProjectile(projectile);
            return true;
        }

        private bool IntersectOABB(Vector2 origin, Vector2 vector, BoxCollider2D? box)
        {
            var localOrigin = (Vector2)box.transform.InverseTransformPoint(origin) - box.offset;
            var localDirection = (Vector2)box.transform.InverseTransformDirection(vector) - box.offset;

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