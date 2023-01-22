using System;
using Com.ThirdNerve.Backfire.Runtime.Health;
using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class KillableEnemyTriggerBehaviour : MonoBehaviour
    {
        private HealthBehaviour? _healthBehaviour;

        private void Awake()
        {
            _healthBehaviour = GetComponent<HealthBehaviour>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectileBehaviour = other.GetComponent<ProjectileBehaviour>();
            if (projectileBehaviour is null || projectileBehaviour.IsReflected is false)
            {
                return;
            }
            
            projectileBehaviour.Owner.RegisterKill();
            _healthBehaviour.Damage(1);
            Destroy(other.gameObject);
        }
    }
}
