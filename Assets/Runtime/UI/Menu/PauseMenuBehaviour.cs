using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI.Menu
{
    [RequireComponent(typeof(UIDocument))]
    public class PauseMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private VisualElement? _root;
        private UIDocument? _uiDocument;
        private Button? _continueButton;

        private void Awake()
        {
            _gameBehaviour.GameStateUpdated += GameStateUpdated;
            _uiDocument = GetComponent<UIDocument>();

            _root = _uiDocument.rootVisualElement;
            
            _continueButton = _root.Q<Button>("continue");
            _continueButton.clicked += OnContinueClicked;
            
            var quitButton = _root.Q<Button>("quit");
            quitButton.clicked += OnQuitClicked;
            
            Hide();
        }

        private void OnContinueClicked()
        {
            _gameBehaviour.Play();
        }
        
        private void OnQuitClicked()
        {
            _gameBehaviour.StopGame();
        }

        private void GameStateUpdated(GameState gameState)
        {
            if (gameState == GameState.Paused)
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
            _uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
            _continueButton.Focus();
        }

        private void Hide()
        {
            _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}