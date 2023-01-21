using Com.ThirdNerve.Backfire.Runtime.Player;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class HealthView : BaseView<HealthView>
    {
        public void Bind(Health health)
        {
            health.HealthUpdated += OnHealthUpdated;
        }

        private void OnHealthUpdated(Health health)
        {
            var progressBar = this.Q<ProgressBar>();
            progressBar.value = health.Current / (float)Health.Max * 100f;
        }

        [UsedImplicitly]
        public new class UxmlFactory : UxmlFactory<HealthView> { }
    }
}