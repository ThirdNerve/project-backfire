using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI.Menu
{
    [RequireComponent(typeof(UIDocument))]
    public class MainMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private UIDocument? _uiDocument;
        private Button? _startButton;

        private void Start()
        {
            _gameBehaviour.GameStateUpdated += OnGameStateUpdated;
            
            _uiDocument = GetComponent<UIDocument>();
            var root = _uiDocument.rootVisualElement;

            _startButton = root.Q<Button>("start");
            _startButton.clicked += OnStartClicked;
            
            var quitButton = root.Q<Button>("quit");
            quitButton.clicked += OnQuitClicked;
            
            Show();
        }

        private void OnStartClicked()
        {
            _gameBehaviour.StartGame();
            Hide();
        }
        
        private static void OnQuitClicked()
        {
            Application.Quit();
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            if (gameState == GameState.Stopped)
            {
                Show();
            }
        }

        private void Show()
        {
            _uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
            _startButton.Focus();
        }

        private void Hide()
        {
            _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}