using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerReflectorBehaviour : MonoBehaviour
    {
    
        private ReflectorDataComponent? _reflectorDataComponent;
        private Rigidbody2D? _reflectorRigidbody2D;
        private Vector2 _input;
    
        private void OnEnable()
        {
            _reflectorDataComponent = GetComponentInChildren<ReflectorDataComponent>() ?? throw new Exception("Fucking thing sucks");
        }

        private void Update()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
            
            
            
            var angleInRadians = Mathf.Atan2(_input.y, _input.x);
            var angle = angleInRadians * Mathf.Rad2Deg;
            Debug.Log(_input);
            Debug.Log(angle);
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            Debug.Assert(_reflectorDataComponent != null, nameof(_reflectorRigidbody2D) + " != null");
            _reflectorDataComponent.transform.rotation = rotation;
        }
    }
}

