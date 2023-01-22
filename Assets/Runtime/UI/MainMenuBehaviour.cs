using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class MainMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private UIDocument? _uiDocument;

        private void OnEnable()
        {
            _uiDocument = GetComponent<UIDocument>();
            var root = _uiDocument.rootVisualElement;

            var startButton = root.Q<Button>("start");
            startButton.clicked += OnStartClicked;
        }

        private void OnStartClicked()
        {
            _gameBehaviour.StartGame();
            _uiDocument.enabled = false;
        }
    }
}