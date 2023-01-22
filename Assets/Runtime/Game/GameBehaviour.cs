using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Game
{
    public class GameBehaviour : MonoBehaviour
    {
        private GameState _gameState = GameState.Stopped;
        public GameState GameState
        {
            get => _gameState;
            private set
            {
                _gameState = value;
                GameStateUpdated?.Invoke(value);
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

        public void Start()
        {
            GameState = GameState.Started;
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

        public void Fail()
        {
            GameState = GameState.Failed;
        }

        public event Action<GameState>? GameStateUpdated;
    }
}