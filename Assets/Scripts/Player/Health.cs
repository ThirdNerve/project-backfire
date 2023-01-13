using System;

namespace Player
{
    public class Health
    {
        private int current;
        public int Max => 3;
        public int Min => 0;

        public int Current
        {
            get => current;
            set
            {
                current = value;
                HealthUpdated?.Invoke(this);
            }
        }

        public event Action<Health> HealthUpdated;
    }
}