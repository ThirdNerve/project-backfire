using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Com.ThirdNerve.Backfire.Runtime.Component
{
    public class HealthBehaviour : MonoBehaviour
    {
        [SerializeField] private int current;
        [SerializeField] private int max = 3;
        [SerializeField] private int min = 0;

        public int Current
        {
            get => current;
            private set
            {
                current = value;
                HealthUpdated?.Invoke(this);
            }
        }

        public int Max => max;

        public void Damage(int damage)
        {
            Current -= damage;
            if (Current <= min)
            {
                Destroy(gameObject);
            }
        }

        public event Action<HealthBehaviour>? HealthUpdated;
    }
}