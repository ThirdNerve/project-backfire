using Com.ThirdNerve.Backfire.Runtime.Component;
using Com.ThirdNerve.Backfire.Runtime.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    [RequireComponent(typeof(HealthBehaviour))]
    [RequireComponent(typeof(KillCountBehaviour))]
    public class HUDBehaviour : MonoBehaviour
    {
        private HealthBehaviour? _healthBehaviour;
        private KillCountBehaviour? _killCountBehaviour;

        private void Awake()
        {
            _healthBehaviour = GetComponent<HealthBehaviour>();
            _killCountBehaviour = GetComponent<KillCountBehaviour>();
        }

        private void OnEnable()
        {
            var uiDocument = GetComponentInChildren<UIDocument>();
            var root = uiDocument.rootVisualElement;

            var killsView = root.Q<KillsView>();
            killsView.Bind(_killCountBehaviour);
            
            var healthView = root.Q<HealthView>();
            healthView.Bind(_healthBehaviour);
        }

        public void RegisterKill()
        {
            _killCountBehaviour.Current += 1;
        }
    }
}