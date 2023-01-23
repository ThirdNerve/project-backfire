using System;
using System.Collections;
using Com.ThirdNerve.Backfire.Runtime.Agent;
using Com.ThirdNerve.Backfire.Runtime.Projectile;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    [RequireComponent(typeof(AgentBehaviour))]
    public class GunnerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject? projectilePrefab;
        private AgentBehaviour? _playerBehaviour;
        private TargetBehaviour? _targetBehaviour;
        private IEnumerator _fireCoroutine;

        private void Awake()
        {
            _playerBehaviour = GetComponent<AgentBehaviour>();
            _targetBehaviour = GetComponent<TargetBehaviour>();
            _targetBehaviour.TargetChanged += OnTargetChanged;
        }

        private void OnDisable()
        {
            _targetBehaviour.TargetChanged -= OnTargetChanged;
        }

        private void OnTargetChanged(TargetableBehaviour? targetableBehaviour)
        {
            if (targetableBehaviour != null)
            {
                _fireCoroutine = FireCoroutine();
                StartCoroutine(_fireCoroutine);
            }
            else
            {
                StopCoroutine(_fireCoroutine);
            }
        }

        private IEnumerator FireCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                var projectileBehaviour = projectile.GetComponent<ProjectileBehaviour>();
                projectileBehaviour.Owner = _playerBehaviour;
            }
        }
    }
}