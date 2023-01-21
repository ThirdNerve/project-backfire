using System.Collections;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float desiredDistanceFromTarget = 5f;
        [SerializeField] private float distanceThreshold = 0.6f;
        [SerializeField] private float maxSpeed = 50f;
        [SerializeField] private float acceleration = 1f;
        
        private TargetBehaviour _targetBehaviour;
        private Rigidbody2D? _rigidbody2D;

        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _targetBehaviour = GetComponent<TargetBehaviour>();
        }

        private void FixedUpdate()
        {
            var targetPosition = _targetBehaviour.Target.position;

            var distanceToTarget = Vector2.Distance(_rigidbody2D.position, targetPosition);
            var vectorToTarget = targetPosition - _rigidbody2D.position;

            var adjustedTargetPosition = _rigidbody2D.position + vectorToTarget.normalized * (distanceToTarget - desiredDistanceFromTarget);

            var vectorToAdjustedTarget = adjustedTargetPosition - _rigidbody2D.position;

            if (!(Mathf.Abs(distanceToTarget - desiredDistanceFromTarget) >= distanceThreshold))
            {
                _rigidbody2D.velocity = Vector2.zero;
                return;
            }
            
            var newSpeed = _rigidbody2D.velocity.magnitude + acceleration * Time.deltaTime;
            _rigidbody2D.velocity = vectorToAdjustedTarget.normalized * Mathf.Min(newSpeed, maxSpeed);
        }
    }
}