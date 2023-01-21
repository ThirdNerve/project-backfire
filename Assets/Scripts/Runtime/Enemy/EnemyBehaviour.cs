using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float desiredDistanceFromTarget = 5f;
        [SerializeField] private float stoppingDistance = 0.1f;
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float acceleration = 1f;
        [SerializeField] private float strafeSpeed = 3f;
        
        private TargetBehaviour _targetBehaviour;
        private Rigidbody2D? _rigidbody2D;
        private float _sineOffset;
        private Vector2 forwardVelocity;

        private void Awake()
        {
            _sineOffset = Random.Range(0, 2 * Mathf.PI);
        }
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _targetBehaviour = GetComponent<TargetBehaviour>();
        }

        private void FixedUpdate()
        {
            var targetPosition = _targetBehaviour.Target.position;

            var distanceToTarget = Vector2.Distance(_rigidbody2D.position, targetPosition);
            var vectorToTarget = (targetPosition - _rigidbody2D.position).normalized;

            var distanceGap = distanceToTarget - desiredDistanceFromTarget;

            var adjustedTargetPosition = _rigidbody2D.position + vectorToTarget * (distanceToTarget - desiredDistanceFromTarget);

            var vectorToAdjustedTarget = adjustedTargetPosition - _rigidbody2D.position;

            var sidewaysVelocity = Vector2.Perpendicular(vectorToTarget) * (strafeSpeed * Mathf.Sin(Time.time + _sineOffset));

            if (Mathf.Abs(distanceToTarget - desiredDistanceFromTarget) >= stoppingDistance)
            {
                var forwardSpeed = forwardVelocity.magnitude;
                if (forwardSpeed * Time.deltaTime < Mathf.Abs(distanceGap))
                {
                    forwardSpeed += acceleration * Time.deltaTime;
                }
                else
                {
                    forwardSpeed -= acceleration * Time.deltaTime;
                }
                forwardVelocity = vectorToAdjustedTarget.normalized * Mathf.Min(forwardSpeed, maxSpeed);
            }
            else
            {
                forwardVelocity = Vector2.zero;
            }
            
            

            var newAngle = Vector2.SignedAngle(vectorToTarget, Vector2.left);
            _rigidbody2D.SetRotation(-newAngle);
            
            _rigidbody2D.velocity = forwardVelocity + sidewaysVelocity;
        }
    }
}