using System.Collections;
using Com.ThirdNerve.Backfire.Runtime.Component;
using Com.ThirdNerve.Backfire.Runtime.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class HUDBehaviour : MonoBehaviour
    {
        private readonly HealthComponent _healthComponent;

        public HUDBehaviour()
        {
            _healthComponent = new HealthComponent();
        }

        private void OnEnable()
        {
            var uiDocument = GetComponentInChildren<UIDocument>();
            var root = uiDocument.rootVisualElement;
            var healthView = root.Q<HealthView>();
            healthView.Bind(_healthComponent);

            StartCoroutine(RandomHealth());
        }

        private IEnumerator RandomHealth()
        {
            while (true)
            {
                _healthComponent.Current = (int)(Random.value * HealthComponent.Max);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}