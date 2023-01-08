using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 300f;
    
        private Rigidbody2D _rigidbody2D;
        private Vector2 _currentInput;
    
        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            _currentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        // Update is called once per physics tick
        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _currentInput * (maxSpeed * Time.deltaTime);
        }
    }
}

