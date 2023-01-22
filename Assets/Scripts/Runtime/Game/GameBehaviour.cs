using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Game
{
    public class GameBehaviour : MonoBehaviour
    {
        private GameState _gameState = GameState.Running;
        public GameState GameState
        {
            get => _gameState;
            private set
            {
                _gameState = value;
                OnGameStateUpdated?.Invoke(value);
            }
        }
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            if (_gameState == GameState.Running)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        private void Play()
        {
            GameState = GameState.Running;
            Time.timeScale = 1f;
        }

        private void Pause()
        {
            GameState = GameState.Paused;
            Time.timeScale = 0;
        }

        public event Action<GameState>? OnGameStateUpdated;
    }
}