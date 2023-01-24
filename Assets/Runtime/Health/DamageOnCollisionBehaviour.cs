using Com.ThirdNerve.Backfire.Runtime.Agent;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Health
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(AgentBehaviour))]
    public class DamageOnCollisionBehaviour : MonoBehaviour
    {
        [SerializeField] private int damage;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var agentBehaviour = GetComponent<AgentBehaviour>();
            var otherAgentBehaviour = other.GetComponent<AgentBehaviour>();
            var otherHealthBehaviour = other.GetComponent<HealthBehaviour>();

            if (otherHealthBehaviour == null || otherAgentBehaviour.Team == agentBehaviour.Team)
            {
                return;
            }

            otherHealthBehaviour.Damage(damage, agentBehaviour);
        }
    }
}