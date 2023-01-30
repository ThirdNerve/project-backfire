using Com.ThirdNerve.Backfire.Runtime.Game;
using Com.ThirdNerve.Backfire.Runtime.Health;
using Com.ThirdNerve.Backfire.Runtime.Stats;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerSpawnBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour? _gameBehaviour;
        [SerializeField] private GameObject? _playerPrefab;
        private GameObject? _player;

        private void Awake()
        {
            _gameBehaviour.GameStateUpdated += OnGameStateUpdated;
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Started:
                    _player = Instantiate(_playerPrefab);
                    _player.GetComponent<FailOnDeathBehaviour>().gameBehaviour = _gameBehaviour;
                    _player.GetComponent<PlayerMovementBehaviour>().gameBehaviour = _gameBehaviour;
                    _player.GetComponent<PlayerReflectorBehaviour>().gameBehaviour = _gameBehaviour;
                    _player.GetComponent<KillCountBehaviour>().gameBehaviour = _gameBehaviour;
                    break;
                case GameState.Stopped:
                    Destroy(_player);
                    break;
            }
        }
    }
}