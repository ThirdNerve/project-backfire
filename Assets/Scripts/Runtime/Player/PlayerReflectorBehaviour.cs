using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerReflectorBehaviour : MonoBehaviour
    {
        private ReflectorDataComponent? _reflectorDataComponent;
        private Rigidbody2D? _reflectorRigidbody2D;
        private Vector2 _input;
    
        private void Awake()
        {
            _reflectorDataComponent = GetComponentInChildren<ReflectorDataComponent>();
        }

        private void Update()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
            if (_input.sqrMagnitude < 0.25)
            {
                _reflectorDataComponent.gameObject.SetActive(false);
                return;
            }

            if (!_reflectorDataComponent.gameObject.activeSelf)
            {
                _reflectorDataComponent.gameObject.SetActive(true);
            }
            

            var angleInRadians = Mathf.Atan2(_input.y, _input.x);
            var angle = angleInRadians * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            _reflectorDataComponent.transform.rotation = rotation;
        }
    }
}

