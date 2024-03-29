﻿using System;
using Com.ThirdNerve.Backfire.Runtime.Agent;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Health
{
    public class HealthBehaviour : MonoBehaviour
    {
        [SerializeField] private int current;
        [SerializeField] private int max;
        [SerializeField] private int min;

        public int Current
        {
            get => current;
            private set
            {
                current = value;
                HealthUpdated?.Invoke(this);
            }
        }

        public int Max => max;
        
        public void Damage(int damage, AgentBehaviour agentBehaviour)
        {
            // Can't die if you're already dead!
            if (Current <= 0)
            {
                return;
            }
            
            Current -= damage;
            if (Current > min)
            {
                return;
            }
            
            agentBehaviour.RegisterKill();
            OnDeath?.Invoke();
        }

        public event Action<HealthBehaviour>? HealthUpdated;
        public event Action? OnDeath;
    }
}