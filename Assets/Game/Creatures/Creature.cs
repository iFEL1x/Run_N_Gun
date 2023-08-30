using UnityEngine;

namespace Game.Creatures
{
    public class Creature : MonoBehaviour
    {
        public float speed;
        private Rigidbody2D _rigidbody;
        
        protected virtual void Update()
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
    }
}

