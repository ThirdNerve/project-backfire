using System.Collections;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float desiredDistanceFromTarget = 5f;
        [SerializeField] private float maxSpeed = 50f;
        [SerializeField] private float acceleration = 1f;
        
        private TargetBehaviour _targetBehaviour;
        private Rigidbody2D? _rigidbody2D;

        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _targetBehaviour = GetComponent<TargetBehaviour>();

            StartCoroutine(UpdatePositionCoroutine());
        }

        private IEnumerator UpdatePositionCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                
                var targetPosition = _targetBehaviour.Target.position;

                var distanceToTarget = Vector2.Distance(_rigidbody2D.position, targetPosition);
                var vectorToTarget = targetPosition - _rigidbody2D.position;

                var adjustedTargetPosition = vectorToTarget.normalized * desiredDistanceFromTarget;

                _rigidbody2D.position = adjustedTargetPosition;
            }
        }

        private void FixedUpdate()
        {

            var newSpeed = _rigidbody2D.velocity.magnitude + acceleration * Time.deltaTime;
            // _rigidbody2D.velocity = vectorToTarget.normalized * Mathf.Min(newSpeed, maxSpeed);
        }
    }
}