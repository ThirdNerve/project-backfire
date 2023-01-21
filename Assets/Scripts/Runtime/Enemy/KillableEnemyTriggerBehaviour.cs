using Com.ThirdNerve.Backfire.Runtime.Player;
using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    [RequireComponent(typeof(TargetBehaviour))]
    public class KillableEnemyTriggerBehaviour : MonoBehaviour
    {
        private TargetBehaviour? _targetBehaviour;
        
        // TODO: Move this out of gameplay behaviour?
        private HUDBehaviour? _hudBehaviour;

        private void Awake()
        {
            _targetBehaviour = GetComponent<TargetBehaviour>();
        }

        private void Start()
        {
            _hudBehaviour = _targetBehaviour.Target.GetComponent<HUDBehaviour>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectileBehaviour = other.GetComponent<ProjectileBehaviour>();
            
            if (projectileBehaviour is null || projectileBehaviour.IsReflected is false)
            {
                return;
            }
            
            Debug.Assert(_hudBehaviour != null, nameof(_hudBehaviour) + " is null");
            _hudBehaviour.RegisterKill();
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}