using Com.ThirdNerve.Backfire.Runtime.Component;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class HealthView : BaseView<HealthView>
    {
        public void Bind(HealthBehaviour healthBehaviour)
        {
            OnHealthUpdated(healthBehaviour);
            healthBehaviour.HealthUpdated += OnHealthUpdated;
        }

        private void OnHealthUpdated(HealthBehaviour healthBehaviour)
        {
            var progressBar = this.Q<ProgressBar>();
            progressBar.value = healthBehaviour.Current / (float)healthBehaviour.Max * 100f;
        }

        [UsedImplicitly]
        public new class UxmlFactory : UxmlFactory<HealthView> { }
    }
}