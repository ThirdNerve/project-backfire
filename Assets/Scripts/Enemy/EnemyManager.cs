using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int spawnCount = 1;
        [FormerlySerializedAs("distance")] [SerializeField] private float radius = 3f;

        private Transform _playerTransform;
        
        public void OnEnable()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
            StartCoroutine(SpawnEnemyCoroutine());
        }
        
        private IEnumerator SpawnEnemyCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                var playerPosition = _playerTransform.position;                
                
                for (var i = 0; i < spawnCount; i++)
                {
                    var angle = i * Mathf.PI * 2 / spawnCount;
                    var x = Mathf.Cos(angle) * radius;
                    var y = Mathf.Sin(angle) * radius;
                    var pos = playerPosition + new Vector3(x, y, 0);
                    var angleDegrees = -angle*Mathf.Rad2Deg;
                    var rot = Quaternion.Euler(0, 0, -angleDegrees);
                    var enemy = Instantiate(enemyPrefab, pos, rot);
                }
            }
        }

    }
}