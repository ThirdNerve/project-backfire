using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

namespace Com.ThirdNerve.Backfire.Runtime.Terrain
{
    public class BoundsColorBehaviour : MonoBehaviour
    {
        [SerializeField] private float changeColourTime = 2f;

        private SpriteRenderer[]? _spriteRenderers;
        private float _timeSinceLastChange;
        private Color _currentColor;
        private Color _nextColor;
        private Light2D[]? _light2Ds;

        private void Awake()
        {
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            _light2Ds = GetComponentsInChildren<Light2D>();
            _currentColor = Random.ColorHSV();
            _nextColor = Random.ColorHSV();
        }

        private void Update()
        {
            _timeSinceLastChange += Time.deltaTime;

            if (_timeSinceLastChange > changeColourTime)
            {
                _currentColor = _nextColor;
                _nextColor = Random.ColorHSV();
                _timeSinceLastChange = 0f;
            }

            var color = Color.Lerp(_currentColor, _nextColor, _timeSinceLastChange / changeColourTime);
            foreach (var spriteRenderer in _spriteRenderers)
            {
                spriteRenderer.color = color;
            }
            foreach (var light2D in _light2Ds)
            {
                light2D.color = color;
            }
        }
    }
}