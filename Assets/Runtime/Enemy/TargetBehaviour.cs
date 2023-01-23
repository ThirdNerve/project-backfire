using System;
using System.Linq;
using Com.ThirdNerve.Backfire.Runtime.Agent;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class TargetBehaviour : MonoBehaviour
    {
        public TargetableBehaviour? Target { get; private set; }
        
        private void Update()
        {
            if (Target != null)
            {
                return;
            }

            FindNewTarget();
        }

        private void FindNewTarget()
        {
            var targetables = FindObjectsOfType<TargetableBehaviour>()
                .Where(it => it.Targetable);
            if (targetables.Any())
            {
                Target = targetables.First();
                Target.TargetableChanged += OnTargetableChanged;
            }
            else
            {
                Target = null;
            }
            TargetChanged?.Invoke(Target);
        }

        private void OnTargetableChanged(bool targetable)
        {
            if (!targetable)
            {
                FindNewTarget();
            }
        }

        public event Action<TargetableBehaviour?>? TargetChanged;
    }
}