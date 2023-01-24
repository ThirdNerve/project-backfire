using Com.ThirdNerve.Backfire.Runtime.Agent;
using Com.ThirdNerve.Backfire.Runtime.Health;
using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    [RequireComponent(typeof(HealthBehaviour))]
    [RequireComponent(typeof(AgentBehaviour))]
    public class KillableEnemyTriggerBehaviour : MonoBehaviour
    {
        private HealthBehaviour? _healthBehaviour;
        private AgentBehaviour? _agentBehaviour;

        private void Awake()
        {
            _healthBehaviour = GetComponent<HealthBehaviour>();
            _agentBehaviour = GetComponent<AgentBehaviour>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectileBehaviour = other.GetComponent<ProjectileBehaviour>();
            if (projectileBehaviour is null || projectileBehaviour.Owner.Team == _agentBehaviour.Team )
            {
                return;
            }

            _healthBehaviour.Damage(projectileBehaviour.Damage, projectileBehaviour.Owner);
            Destroy(other.gameObject);
        }
    }
}
