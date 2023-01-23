using Com.ThirdNerve.Backfire.Runtime.Input;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class PlayerInputBehaviour : MonoBehaviour
    {
        public InputActions InputActions { get; private set; }

        private void Awake()
        {
            InputActions = new InputActions();
        }

        private void OnEnable()
        {
            InputActions.Enable();
        }

        private void OnDisable()
        {
            InputActions.Disable();
        }
    }
}