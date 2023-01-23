using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Agent
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TargetableBehaviour : MonoBehaviour
    {
        private bool _targetable = true;
        private Rigidbody2D? _rigidbody2D;

        public bool Targetable
        {
            get => _targetable;
            set
            {
                _targetable = value;
                TargetableChanged?.Invoke(value);
            }
        }

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        
        public event Action<bool>? TargetableChanged;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void OnDestroy()
        {
            Targetable = false;
        }
    }
}
