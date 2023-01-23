using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI.Menu
{
    [RequireComponent(typeof(UIDocument))]
    public class FailedMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private UIDocument? _uiDocument;
        private VisualElement? _root;
        private Button? _retryButton;

        private void Awake()
        {
            _gameBehaviour.GameStateUpdated += GameStateUpdated;
            _uiDocument = GetComponent<UIDocument>();

            _root = _uiDocument.rootVisualElement;

            _retryButton = _root.Q<Button>("retry");
            _retryButton.clicked += OnRetryClicked;

            var quitButton = _root.Q<Button>("quit");
            quitButton.clicked += OnQuitClicked;
            
            Hide();
        }

        private void OnRetryClicked()
        {
            _gameBehaviour.StartGame();
        }

        private void OnQuitClicked()
        {
            _gameBehaviour.StopGame();
        }

        private void GameStateUpdated(GameState gameState)
        {
            if (gameState == GameState.Failed)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            _root.style.display = DisplayStyle.Flex;
            _retryButton.Focus();
        }

        private void Hide()
        {
            _root.style.display = DisplayStyle.None;
        }
    }
}