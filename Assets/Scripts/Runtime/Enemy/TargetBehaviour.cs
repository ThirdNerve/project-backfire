﻿using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class TargetBehaviour : MonoBehaviour
    {
        public Rigidbody2D Target { get; private set; }

        public void OnEnable()
        {
            Target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }
}