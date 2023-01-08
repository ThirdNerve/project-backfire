using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 100f;
        [SerializeField] private float acceleration = 1f;
    
        private Rigidbody2D _rigidbody2D;
        private Vector2 _currentInput;
    
        // Start is called before the first frame update
        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            _currentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void FixedUpdate()
        {
            var newVelocity = _currentInput * (acceleration * Time.deltaTime);

            //_rigidbody2D.velocity += Vector2.ClampMagnitude(newVelocity, maxSpeed);

            _rigidbody2D.velocity = _currentInput * (maxSpeed * Time.deltaTime);
        }
    }
}

