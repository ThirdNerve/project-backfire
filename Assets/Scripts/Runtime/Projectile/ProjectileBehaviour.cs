using System;
using Com.ThirdNerve.Backfire.Runtime.Player;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 50f;
        [SerializeField] private float timeToLive = 5f;

        private Rigidbody2D? _rigidbody2D;
        private SpriteRenderer? _spriteRenderer;
        
        public bool IsReflected { get; private set; }
        public Vector2 Velocity => _rigidbody2D.velocity;
        public event Action<PlayerBehaviour?>? OwnerUpdated;

        private PlayerBehaviour? _owner;
        public PlayerBehaviour? Owner
        {
            get => _owner;
            set
            {
                _owner = value;
                OwnerUpdated?.Invoke(value);
            }
        }

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

        public void Reflect(Vector2 reflectedVelocity, PlayerBehaviour? newOwner)
        {
            if (Owner.Team == newOwner.Team)
            {
                return;
            }
            
            IsReflected = true;
            Owner = newOwner;
            var newAngle = Vector2.SignedAngle(reflectedVelocity, Vector2.left);
            _rigidbody2D.SetRotation(-newAngle);
            _rigidbody2D.velocity = reflectedVelocity;
            _spriteRenderer.color = Color.green;
        }
    }
}