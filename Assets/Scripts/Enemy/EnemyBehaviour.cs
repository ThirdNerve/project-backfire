using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 50f;
        [SerializeField] private float acceleration = 1f;
        [SerializeField] private float timeToLive = 5f;
    
        private Rigidbody2D _rigidbody2D;
    
        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Destroy(gameObject, timeToLive);
        }

        private void FixedUpdate()
        {
            var newSpeed = _rigidbody2D.velocity.magnitude + acceleration * Time.deltaTime;

            _rigidbody2D.velocity = -_rigidbody2D.transform.right * Mathf.Min(newSpeed, maxSpeed);
        }
    }
}