using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private TargetBehaviour _targetBehaviour;
        private Rigidbody2D? _rigidbody2D;

        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _targetBehaviour = GetComponent<TargetBehaviour>();
        }
    }
}