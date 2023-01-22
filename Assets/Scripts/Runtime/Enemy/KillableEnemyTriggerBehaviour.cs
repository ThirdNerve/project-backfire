using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class KillableEnemyTriggerBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectileBehaviour = other.GetComponent<ProjectileBehaviour>();
            if (projectileBehaviour is null || projectileBehaviour.IsReflected is false)
            {
                return;
            }
            
            projectileBehaviour.Owner.RegisterKill();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
