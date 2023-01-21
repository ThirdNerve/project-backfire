using Com.ThirdNerve.Backfire.Runtime.Component;
using Com.ThirdNerve.Backfire.Runtime.Player;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class HealthView : BaseView<HealthView>
    {
        public void Bind(HealthComponent healthComponent)
        {
            healthComponent.HealthUpdated += OnHealthUpdated;
        }

        private void OnHealthUpdated(HealthComponent healthComponent)
        {
            var progressBar = this.Q<ProgressBar>();
            progressBar.value = healthComponent.Current / (float)HealthComponent.Max * 100f;
        }

        [UsedImplicitly]
        public new class UxmlFactory : UxmlFactory<HealthView> { }
    }
}