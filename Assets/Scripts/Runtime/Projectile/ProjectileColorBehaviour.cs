using Com.ThirdNerve.Backfire.Runtime.Player;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Projectile
{
    [RequireComponent(typeof(ProjectileBehaviour))]
    public class ProjectileColorBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private ProjectileBehaviour _projectileBehaviour;

        private void Awake()
        {
            _projectileBehaviour = GetComponent<ProjectileBehaviour>();
            _projectileBehaviour.OwnerUpdated += UpdateColor;
        }

        private void UpdateColor(PlayerBehaviour owner)
        {
            _spriteRenderer.color = owner.Team switch
            {
                Team.Player => Color.green,
                Team.AI => Color.red,
                _ => _spriteRenderer.color
            };
        }
    }
}