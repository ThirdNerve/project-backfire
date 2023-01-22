using System.Linq;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerReflectorBehaviour : MonoBehaviour
    {
        private ReflectorDataComponent? _reflectorDataComponent;
        private Rigidbody2D? _playerRigidbody2D;

        private void Awake()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _reflectorDataComponent = GetComponentInChildren<ReflectorDataComponent>();
        }

        private void Update()
        {
            Quaternion rotation;
            
            if (Input.GetJoystickNames().Any())
            {
                var input = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
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

                var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var mouseWorldPosition2d = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

                var angle = Vector2.SignedAngle(mouseWorldPosition2d - _playerRigidbody2D.position, Vector2.right);
                rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
            }

            _reflectorDataComponent.transform.rotation = rotation;
        }
    }
}