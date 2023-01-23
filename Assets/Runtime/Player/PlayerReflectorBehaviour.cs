using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerReflectorBehaviour : MonoBehaviour
    {
        public GameBehaviour? gameBehaviour;
        private ReflectorDataComponent? _reflectorDataComponent;
        private Rigidbody2D? _playerRigidbody2D;
        private PlayerInputBehaviour? _playerInputBehaviour;

        private void Awake()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _playerInputBehaviour = GetComponent<PlayerInputBehaviour>();
            _reflectorDataComponent = GetComponentInChildren<ReflectorDataComponent>();
        }

        private void Update()
        {
            if (gameBehaviour.GameState != GameState.Running)
            {
                return;
            }

            Quaternion rotation;

            if (_playerInputBehaviour.InputActions.Player.Look.inProgress)
            {
                var input = _playerInputBehaviour.InputActions.Player.Look.ReadValue<Vector2>();
                if (input.sqrMagnitude < 0.25)
                {
                    _reflectorDataComponent.gameObject.SetActive(false);
                    return;
                }

                if (!_reflectorDataComponent.gameObject.activeSelf)
                {
                    _reflectorDataComponent.gameObject.SetActive(true);
                }

                var angleInRadians = Mathf.Atan2(input.y, input.x);
                var angle = angleInRadians * Mathf.Rad2Deg;
                rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                if (!_reflectorDataComponent.gameObject.activeSelf)
                {
                    _reflectorDataComponent.gameObject.SetActive(true);
                }

                var mouseWorldPosition =
                    Camera.main.ScreenToWorldPoint(_playerInputBehaviour.InputActions.Player.LookMouse.ReadValue<Vector2>());
                var mouseWorldPosition2d = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

                var angle = Vector2.SignedAngle(mouseWorldPosition2d - _playerRigidbody2D.position, Vector2.right);
                rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
            }

            _reflectorDataComponent.transform.rotation = rotation;
        }
    }
}