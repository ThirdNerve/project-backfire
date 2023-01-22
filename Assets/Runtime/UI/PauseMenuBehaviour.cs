using System;
using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class PauseMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        private UIDocument? _menuDocument;

        private void Awake()
        {
            _menuDocument = GetComponent<UIDocument>();
            _gameBehaviour.OnGameStateUpdated += OnGameStateUpdated;
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            _menuDocument.enabled = gameState switch
            {
                GameState.Running => false,
                GameState.Paused => true,
                GameState.Failed => false,
                _ => throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null)
            };
        }
    }
}