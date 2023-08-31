using Spine.Unity;
using UnityEngine;

namespace Game.Creatures
{
    public class Creature : MonoBehaviour
    {
        public float speed;
        [SerializeField] protected new SkeletonAnimation animation;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            animation = GetComponentInChildren<SkeletonAnimation>();
        }

        protected virtual void Update()
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
    }
}

