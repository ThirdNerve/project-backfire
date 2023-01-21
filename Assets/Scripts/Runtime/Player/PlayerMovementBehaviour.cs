using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 300f;
    
        private Rigidbody2D? _rigidbody2D;
        private Vector2 _currentInput;
    
        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _currentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void FixedUpdate()
        {
            Debug.Assert(_rigidbody2D != null, nameof(_rigidbody2D) + " != null");
            
            _rigidbody2D.velocity = _currentInput * (maxSpeed * Time.deltaTime);
        }
    }
}
