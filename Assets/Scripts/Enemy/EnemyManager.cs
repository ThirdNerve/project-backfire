using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        private Transform _playerTransform;
        
        public void OnEnable()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
            StartCoroutine(SpawnEnemyCoroutine());
        }

        public void Update()
        {
            
        }

        
        
        private IEnumerator SpawnEnemyCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                var playerPosition = _playerTransform.position;                
                var westEnemy = Instantiate(enemyPrefab,  playerPosition + new Vector3(-5, 0, 0), Quaternion.identity);
                var eastEnemy = Instantiate(enemyPrefab, playerPosition + new Vector3(5, 0, 0), Quaternion.identity);
                var northEnemy = Instantiate(enemyPrefab, playerPosition + new Vector3(0, 5, 0), Quaternion.identity);
                var southEnemy = Instantiate(enemyPrefab, playerPosition + new Vector3(0, -5, 0), Quaternion.identity);
            }
        }

    }
}