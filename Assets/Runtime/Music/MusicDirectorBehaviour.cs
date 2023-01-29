using System;
using System.Collections;
using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Music
{
    public class MusicDirectorBehaviour : MonoBehaviour
    {
        [SerializeField] private GameBehaviour _gameBehaviour;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _menuMusic;
        [SerializeField] private AudioClip _gameMusic;
        
        private void OnEnable()
        {
            _gameBehaviour.GameStateUpdated += OnGameStateUpdated;
        }

        private void OnGameStateUpdated(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Started:
                    StartCoroutine(Crossfade(_gameMusic, 2f));
                    break;
                case GameState.Running:
                    break;
                case GameState.Paused:
                    break;
                case GameState.Failed:
                    break;
                case GameState.Stopped:
                    StartCoroutine(Crossfade(_menuMusic, 1f));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
            }
        }
        
        private IEnumerator Crossfade(AudioClip newClip, float duration)
        {
            float currentTime = 0;
            float startVolume = _audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
                yield return null;
            }
            _audioSource.Stop();
            _audioSource.clip = newClip;
            _audioSource.Play();
            currentTime = 0;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(0, startVolume, currentTime / duration);
                yield return null;
            }
        }
    }
}