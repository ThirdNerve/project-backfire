using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        public GameBehaviour? gameBehaviour;
        private Rigidbody2D? _rigidbody2D;
        private PlayerInputBehaviour? _playerInputBehaviour;
        [SerializeField] private float maxSpeed = 300f;

        private Vector2 _currentInput;

        private void Awake()
        {
            _playerInputBehaviour = GetComponent<PlayerInputBehaviour>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            _playerInputBehaviour.InputActions.Player.Pause.performed += OnPausePerformed;
            
            if (gameBehaviour.GameState != GameState.Running)
            {
                return;
            }

            _currentInput = _playerInputBehaviour.InputActions.Player.Move.ReadValue<Vector2>();
        }

        private void OnPausePerformed(InputAction.CallbackContext callbackContext)
        {
            gameBehaviour.Pause();
        }

        private void FixedUpdate()
        {
            _rigidbody2D!.velocity = _currentInput * (maxSpeed * Time.deltaTime);
        }
    }
}

