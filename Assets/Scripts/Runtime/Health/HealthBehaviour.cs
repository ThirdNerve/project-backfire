using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Health
{
    public class HealthBehaviour : MonoBehaviour
    {
        [SerializeField] private int current;
        [SerializeField] private int max;
        [SerializeField] private int min;

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

        /**
         * <returns>true if the target was destroyed.</returns>
         */
        public bool Damage(int damage)
        {
            Current -= damage;
            if (Current > min)
            {
                return false;
            }
            
            OnDeath?.Invoke();
            return true;
        }

        public event Action<HealthBehaviour>? HealthUpdated;
        public event Action? OnDeath;
    }
}