using UnityEngine;

namespace Com.ThirdNerve.Backfire.Runtime.Player
{
    public class ReflectorTriggerBehaviour : MonoBehaviour
    {
        //Upon collision with another GameObject, this GameObject will reverse direction
        private Rigidbody2D _player;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            var angleOfIncidence = GetAngleOfIncidence(other.transform);
        
        
        
        }

        private float GetAngleOfIncidence(Transform otherTransform)
        {
            throw new System.NotImplementedException();
        }
    }
}
