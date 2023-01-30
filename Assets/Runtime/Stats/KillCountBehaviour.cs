using System;
using Com.ThirdNerve.Backfire.Runtime.Game;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Stats
{
    public class KillCountBehaviour : MonoBehaviour
    {
        public GameBehaviour? gameBehaviour;
        private int _current;

        public int Current
        {
            get => _current;
            set
            {
                _current = value;
                if (gameBehaviour != null)
                {
                    gameBehaviour.Kills = value;
                }

                KillsUpdated?.Invoke(this);
            }
        }

        public event Action<KillCountBehaviour>? KillsUpdated;
    }
}