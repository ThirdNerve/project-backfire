using Com.ThirdNerve.Backfire.Runtime.Stats;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class KillsView : BaseView<KillsView>
    {
        public void Bind(KillCountBehaviour killCountBehaviour)
        {
            OnKillsUpdated(killCountBehaviour);
            killCountBehaviour.KillsUpdated += OnKillsUpdated;
        }

        private void OnKillsUpdated(KillCountBehaviour killCountBehaviour)
        {
            var textElement = this.Q<TextElement>();
            textElement.text = $"Kills: {killCountBehaviour.Current.ToString()}";
        }

        [UsedImplicitly]
        public new class UxmlFactory : UxmlFactory<KillsView> { }
    }
}