using System;

namespace Com.ThirdNerve.Backfire.Runtime.Component
{
    public class KillsComponent
    {
        private int _current;

        public int Current
        {
            get => _current;
            set
            {
                _current = value;
                KillsUpdated?.Invoke(this);
            }
        }

        public event Action<KillsComponent>? KillsUpdated;
    }
}