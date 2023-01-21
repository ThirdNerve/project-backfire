using System.Collections;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class GunnerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject? projectilePrefab;

        private Rigidbody2D? _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartCoroutine(FireCoroutine());
        }

        private IEnumerator FireCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Instantiate(projectilePrefab, transform.position, transform.rotation);
            }
        }
    }
}