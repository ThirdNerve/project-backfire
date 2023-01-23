using System;
using Com.ThirdNerve.Backfire.Runtime.Game;
using Com.ThirdNerve.Backfire.Runtime.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        public GameBehaviour? gameBehaviour;

        [SerializeField] private float maxSpeed = 300f;
    
        private Rigidbody2D? _rigidbody2D;
        private Vector2 _currentInput;
        private InputActions? _inputActions;

        private void Awake()
        {
            _inputActions = new InputActions();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void Update()
        {
            _inputActions.Player.Pause.performed += OnPausePerformed;
            
            if (gameBehaviour.GameState != GameState.Running)
            {
                return;
            }

            _currentInput = _inputActions.Player.Move.ReadValue<Vector2>();
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

