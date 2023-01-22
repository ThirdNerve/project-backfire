using System;
using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class FailedMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private UIDocument? _uiDocument;

        private void Awake()
        {
            _gameBehaviour.GameStateUpdated += GameStateUpdated;
            _uiDocument = GetComponent<UIDocument>();
            
            var root = _uiDocument.rootVisualElement;

            var retryButton = root.Q<Button>("retry");
            retryButton.clicked += OnRetryClicked;
        }

        private void OnRetryClicked()
        {
            _gameBehaviour.StartGame();
            _uiDocument.enabled = false;
        }

        private void GameStateUpdated(GameState gameState)
        {
            if (gameState == GameState.Failed)
            {
                _uiDocument.enabled = true;
            }
        }
    }
}