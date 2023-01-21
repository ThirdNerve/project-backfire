using System;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class Health
    {
        private int _current;
        public static int Max => 3;
        public static int Min => 0;

        public int Current
        {
            get => _current;
            set
            {
                _current = value;
                HealthUpdated?.Invoke(this);
            }
        }

        public event Action<Health>? HealthUpdated;
    }
}