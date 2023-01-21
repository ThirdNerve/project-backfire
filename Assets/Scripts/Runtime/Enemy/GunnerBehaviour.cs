using System.Collections;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class GunnerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject? projectilePrefab;

        private Rigidbody2D? _rigidbody2D;

        public void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            StartCoroutine(FireCoroutine());
        }

        private IEnumerator FireCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Instantiate(projectilePrefab, _rigidbody2D.transform);
            }
        }
    }
}