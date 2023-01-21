using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class ReflectorTriggerBehaviour : MonoBehaviour
    {
        private Rigidbody2D _player;
        private Collider2D _reflectorCollider;

        private void OnEnable()
        {
            _player = GetComponentInParent<Rigidbody2D>();
            _reflectorCollider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherRigidbody = other.GetComponent<Rigidbody2D>();
            if (otherRigidbody is null)
            {
                return;
            }
            
            var otherVelocity = otherRigidbody.velocity;
            var playerVelocity = _player.velocity;

            var combinedVelocity = playerVelocity + otherVelocity;

            var reflectorCenter = _reflectorCollider.bounds.center;
            var reflectorNormal = ((Vector2) reflectorCenter - _player.position).normalized;
            
            var reflectedVelocity = Vector2.Reflect(otherVelocity, reflectorNormal);

            otherRigidbody.velocity = reflectedVelocity;
        }
    }
}
