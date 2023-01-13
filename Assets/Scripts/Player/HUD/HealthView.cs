using UnityEngine.UIElements;

namespace Player.HUD
{
    public class HealthView
    {
        private ProgressBar progressBar;

        public HealthView(VisualElement root, Health health)
        {
            progressBar = root.Q<ProgressBar>();

            health.HealthUpdated += OnHealthUpdated;
        }

        private void OnHealthUpdated(Health health)
        {
            progressBar.value = health.Current / (float)health.Max * 100f;
        }
    }
}