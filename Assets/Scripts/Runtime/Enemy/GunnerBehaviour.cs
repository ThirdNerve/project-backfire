using System.Collections;
using Com.ThirdNerve.Backfire.Runtime.Player;
using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    [RequireComponent(typeof(PlayerBehaviour))]
    public class GunnerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject? projectilePrefab;
        private PlayerBehaviour? _playerBehaviour;

        private void Awake()
        {
            _playerBehaviour = GetComponent<PlayerBehaviour>();
        }

        private void OnEnable()
        {
            StartCoroutine(FireCoroutine());
        }

        private IEnumerator FireCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                var projectileBehaviour = projectile.GetComponent<ProjectileBehaviour>();
                projectileBehaviour.Owner = _playerBehaviour;
            }
        }
    }
}