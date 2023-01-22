using Com.ThirdNerve.Backfire.Runtime.Player;
using Com.ThirdNerve.Backfire.Runtime.Stats;
using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Agent
{
    public class AgentBehaviour : MonoBehaviour
    {
        [SerializeField] public Team team;
        
        private KillCountBehaviour? _killCountBehaviour;

        private void Awake()
        {
            _killCountBehaviour = GetComponent<KillCountBehaviour>();
        }

        public Team Team
        {
            get => team;
            set => team = value;
        }
        
        public void RegisterKill()
        {
            if (_killCountBehaviour != null)
            {
                _killCountBehaviour.Current += 1;
            }
        }
    }
}