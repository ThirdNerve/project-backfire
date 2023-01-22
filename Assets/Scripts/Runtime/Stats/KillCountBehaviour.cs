using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Stats
{
    public class KillCountBehaviour : MonoBehaviour
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

        public event Action<KillCountBehaviour>? KillsUpdated;
    }
}