using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Com.ThirdNerve.Backfire.Runtime.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 50f;
        //[SerializeField] private float acceleration = 1f;
        [SerializeField] private float timeToLive = 5f;

        public bool IsReflected { get; private set; }
        public Vector2 Velocity => _rigidbody2D.velocity;

        private Rigidbody2D? _rigidbody2D;

        private SpriteRenderer? _spriteRenderer;
    
        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            _rigidbody2D.velocity = transform.right * -maxSpeed;
            Destroy(gameObject, timeToLive);
        }

        public void Reflect(Vector2 reflectedVelocity)
        {
            if (IsReflected)
            {
                return;
            }
            
            IsReflected = true;
            var newAngle = Vector2.SignedAngle(reflectedVelocity, Vector2.left);
            _rigidbody2D.SetRotation(-newAngle);
            _rigidbody2D.velocity = reflectedVelocity;
            _spriteRenderer.color = Color.green;
        }

        // private void FixedUpdate()
        // {
        //     Debug.Assert(_rigidbody2D != null, nameof(_rigidbody2D) + " != null");
        //     
        //     var newSpeed = _rigidbody2D.velocity.magnitude + acceleration * Time.deltaTime;
        //     
        //     _rigidbody2D.velocity = -_rigidbody2D.transform.right * Mathf.Min(newSpeed, maxSpeed);
        // }
    }
}