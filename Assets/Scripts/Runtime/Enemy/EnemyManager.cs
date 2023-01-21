using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    [RequireComponent(typeof(TargetBehaviour))]
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject? enemyPrefab;
        [SerializeField] private int spawnCount = 1;

        [SerializeField]
        private float radius = 3f;

        private TargetBehaviour? _targetBehaviour;

        private void Awake()
        {
            _targetBehaviour = GetComponent<TargetBehaviour>();
        }
        
        private void Start()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            Debug.Assert(_targetBehaviour.Target != null, nameof(_targetBehaviour.Target) + " is null");

            var playerPosition = _targetBehaviour.Target.position;

            for (var i = 0; i < spawnCount; i++)
            {
                var angle = i * Mathf.PI * 2 / spawnCount;
                var x = Mathf.Cos(angle) * radius;
                var y = Mathf.Sin(angle) * radius;
                var pos = playerPosition + new Vector2(x, y);
                var angleDegrees = -angle * Mathf.Rad2Deg;
                var rot = Quaternion.Euler(0, 0, -angleDegrees);
                Instantiate(enemyPrefab, pos, rot);
            }
        }
    }
}