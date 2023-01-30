using System;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Game
{
    public class GameBehaviour : MonoBehaviour
    {
        public int Kills;
        
        [SerializeField] private GameState gameState = GameState.Stopped;
        public GameState GameState
        {
            get => gameState;
            private set
            {
                gameState = value;
                GameStateUpdated?.Invoke(value);
            }
        }

        public void StartGame()
        {
            GameState = GameState.Started;
            GameState = GameState.Running;
        }

        public void Play()
        {
            GameState = GameState.Running;
            Time.timeScale = 1f;
        }

        public void Pause()
        {
            GameState = GameState.Paused;
            Time.timeScale = 0;
        }
        
        public void StopGame()
        {
            GameState = GameState.Stopped;
            Kills = 0;
            Time.timeScale = 1f;
        }

        public void Fail()
        {
            GameState = GameState.Failed;
        }

        public event Action<GameState>? GameStateUpdated;
    }
}