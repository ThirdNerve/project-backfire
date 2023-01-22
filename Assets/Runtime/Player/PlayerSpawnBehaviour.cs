using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerSpawnBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        [SerializeField] private GameObject? _playerPrefab;

        private void Awake()
        {
            _gameBehaviour.GameStateUpdated += OnGameStateUpdated;
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            if (gameState != GameState.Started)
            {
                return;
            }

            Instantiate(_playerPrefab);
        }
    }
}