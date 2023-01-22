using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class FailedMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private UIDocument? _menuDocument;

        private void Awake()
        {
            _menuDocument = GetComponent<UIDocument>();
            _gameBehaviour.GameStateUpdated += GameStateUpdated;
        }

        private void GameStateUpdated(GameState gameState)
        {
            if (gameState == GameState.Failed)
            {
                _menuDocument.enabled = true;
            }
        }
    }
}