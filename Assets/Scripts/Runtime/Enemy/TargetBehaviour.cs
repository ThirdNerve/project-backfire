using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Enemy
{
    public class TargetBehaviour : MonoBehaviour
    {
        public Transform? Target { get; private set; }

        public void OnEnable()
        {
            Target = GameObject.FindWithTag("Player").transform;
        }
    }
}