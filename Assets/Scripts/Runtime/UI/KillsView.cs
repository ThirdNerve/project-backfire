using Com.ThirdNerve.Backfire.Runtime.Component;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class KillsView : BaseView<KillsView>
    {
        public void Bind(KillsComponent killsComponent)
        {
            killsComponent.KillsUpdated += OnKillsUpdated;
        }

        private void OnKillsUpdated(KillsComponent killsComponent)
        {
            var textElement = this.Q<TextElement>();
            textElement.text = $"Kills: {killsComponent.Current.ToString()}";
        }

        [UsedImplicitly]
        public new class UxmlFactory : UxmlFactory<KillsView> { }
    }
}