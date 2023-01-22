using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    [RequireComponent(typeof(TargetBehaviour))]
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject[]? enemyPrefabs;
        [SerializeField] private int spawnCount = 1;
        [SerializeField] private float radius = 3f;

        private void Awake()
        {
            var targetBehaviour = GetComponent<TargetBehaviour>();
            targetBehaviour.TargetUpdated += (target) => StartCoroutine(SpawnEnemies(target));
        }
        
        private IEnumerator SpawnEnemies(Rigidbody2D target)
        {
            while (target != null)
            {
                var enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                
                for (var i = 0; i < spawnCount; i++)
                {
                    var angle = i * Mathf.PI * 2 / spawnCount;
                    var x = Mathf.Cos(angle) * radius;
                    var y = Mathf.Sin(angle) * radius;
                    var pos = target.position + new Vector2(x, y);
                    var angleDegrees = -angle * Mathf.Rad2Deg;
                    var rot = Quaternion.Euler(0, 0, -angleDegrees);
                    Instantiate(enemyPrefab, pos, rot);
                }

                yield return new WaitForSeconds(6f);
            }
        }
    }
}