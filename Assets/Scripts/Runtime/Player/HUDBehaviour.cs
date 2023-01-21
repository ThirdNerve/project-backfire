using System.Collections;
using Com.ThirdNerve.Backfire.Runtime.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Com.ThirdNerve.Backfire.Runtime.Player.HUD
{
    public class HUDBehaviour : MonoBehaviour
    {
        private readonly Health _health;

        public HUDBehaviour()
        {
            _health = new Health();
        }

        private void OnEnable()
        {
            var uiDocument = GetComponentInChildren<UIDocument>();
            var root = uiDocument.rootVisualElement;
            var healthView = root.Q<HealthView>();
            healthView.Bind(_health);

            StartCoroutine(RandomHealth());
        }

        private IEnumerator RandomHealth()
        {
            while (true)
            {
                _health.Current = (int)(Random.value * Health.Max);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}