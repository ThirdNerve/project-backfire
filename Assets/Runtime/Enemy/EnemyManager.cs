using System;
using System.Collections;
using Com.ThirdNerve.Backfire.Runtime.Agent;
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
        private TargetBehaviour? _targetBehaviour;

        private void OnEnable()
        {
            _targetBehaviour = GetComponent<TargetBehaviour>();
            _targetBehaviour.TargetChanged += StartSpawnEnemies;
        }

        private void OnDisable()
        {
            _targetBehaviour.TargetChanged -= StartSpawnEnemies;
        }

        private void StartSpawnEnemies(TargetableBehaviour? target)
        {
            StartCoroutine(SpawnEnemies(target));
        }

        private IEnumerator SpawnEnemies(TargetableBehaviour? targetableBehaviour)
        {
            while (targetableBehaviour != null)
            {
                var enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                
                for (var i = 0; i < spawnCount; i++)
                {
                    var angle = i * Mathf.PI * 2 / spawnCount;
                    var x = Mathf.Cos(angle) * radius;
                    var y = Mathf.Sin(angle) * radius;
                    var pos = targetableBehaviour.Rigidbody2D.position + new Vector2(x, y);
                    var angleDegrees = -angle * Mathf.Rad2Deg;
                    var rot = Quaternion.Euler(0, 0, -angleDegrees);
                    Instantiate(enemyPrefab, pos, rot);
                }

                yield return new WaitForSeconds(6f);
            }
        }
    }
}