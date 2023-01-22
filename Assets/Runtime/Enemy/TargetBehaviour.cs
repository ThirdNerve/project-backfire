using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class TargetBehaviour : MonoBehaviour
    {
        public Rigidbody2D? Target { get; private set; }
        
        private void Update()
        {
            if (Target != null)
            {
                return;
            }

            var foundTarget = GameObject.FindWithTag("Player");
            if (foundTarget == null)
            {
                return;
            }
            
            Target = foundTarget.GetComponent<Rigidbody2D>();
            TargetUpdated?.Invoke(Target);
        }

        public event Action<Rigidbody2D>? TargetUpdated;
    }
}