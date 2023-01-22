using UnityEngine;
using Random = UnityEngine.Random;

namespace Com.ThirdNerve.Backfire.Runtime.Scenery
{
    public class BoundsColorBehaviour : MonoBehaviour
    {
        [SerializeField] private float changeColourTime = 2f;

        private SpriteRenderer[]? _spriteRenderers;
        private float _timeSinceLastChange;
        private Color _currentColor;
        private Color _nextColor;

        private void Awake()
        {
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
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

            foreach (var spriteRenderer in _spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(_currentColor, _nextColor, _timeSinceLastChange / changeColourTime);
            }
        }
    }
}