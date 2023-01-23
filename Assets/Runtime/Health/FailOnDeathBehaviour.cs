using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Health
{
    [RequireComponent(typeof(HealthBehaviour))]
    public class FailOnDeathBehaviour : MonoBehaviour
    {
        public GameBehaviour? gameBehaviour;
        
        private void Awake()
        {
            var healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            gameBehaviour.Fail();
        }
    }
}
