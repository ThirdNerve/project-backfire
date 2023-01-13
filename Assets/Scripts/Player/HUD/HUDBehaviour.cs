using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Player.HUD
{
    public class HUDBehaviour : MonoBehaviour
    {
        private HealthView healthView;
        private Health health;

        private void OnEnable()
        {
            var menu = GetComponentInChildren<UIDocument>();
            var root = menu.rootVisualElement;
            health = new Health();
            healthView = new HealthView(root, health);

            StartCoroutine(RandomHealth());
        }

        private IEnumerator RandomHealth()
        {
            while (true)
            {
                health.Current = (int)(Random.value * health.Max);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}