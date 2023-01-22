using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Health
{
    [RequireComponent(typeof(HealthBehaviour))]
    public class DestroyOnDeathBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        
        private void Awake()
        {
            var healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            _gameBehaviour.Fail();
            Destroy(gameObject);
        }
    }
}
