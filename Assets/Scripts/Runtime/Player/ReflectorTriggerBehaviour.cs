using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class ReflectorTriggerBehaviour : MonoBehaviour
    {
        private Rigidbody2D? _playerRigidbody2D;
        private Collider2D? _reflectorCollider;

        private void Awake()
        {
            _playerRigidbody2D = GetComponentInParent<Rigidbody2D>();
            _reflectorCollider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectile = other.GetComponent<ProjectileBehaviour>();
            ReflectProjectile(projectile);
        }

        public void ReflectProjectile(ProjectileBehaviour? projectile)
        {
            if (projectile is null || projectile.IsReflected)
            {
                return;
            }
            
            var projectileVelocity = projectile.Velocity;
            var playerVelocity = _playerRigidbody2D!.velocity;

            var combinedVelocity = projectileVelocity - playerVelocity;

            var reflectorCenter = _reflectorCollider!.bounds.center;
            var reflectorNormal = ((Vector2) reflectorCenter - _playerRigidbody2D.position).normalized;

            var reflectedVelocity = Vector2.Reflect(combinedVelocity, reflectorNormal);
            
            projectile.Reflect(reflectedVelocity);
        }
    }
}
