﻿using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Health
{
    [RequireComponent(typeof(HealthBehaviour))]
    public class DestroyOnDeathBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            var healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
