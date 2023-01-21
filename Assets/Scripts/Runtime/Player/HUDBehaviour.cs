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
        private readonly KillsComponent _killsComponent;

        public HUDBehaviour()
        {
            _healthComponent = new HealthComponent();
            _killsComponent = new KillsComponent();
        }

        private void Start()
        {
            var uiDocument = GetComponentInChildren<UIDocument>();
            var root = uiDocument.rootVisualElement;

            var killsView = root.Q<KillsView>();
            killsView.Bind(_killsComponent);
            
            var healthView = root.Q<HealthView>();
            healthView.Bind(_healthComponent);

            StartCoroutine(RandomHealth());
        }

        public void RegisterKill()
        {
            _killsComponent.Current += 1;
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