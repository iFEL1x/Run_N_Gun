using Spine.Unity;
using UnityEngine;

namespace Game.Creatures
{
    public class Creature : MonoBehaviour
    {
        public float speed;
        [SerializeField] protected new SkeletonAnimation animation;

        private void Awake()
        {
            if(animation == null)
                animation = GetComponentInChildren<SkeletonAnimation>();
        }

        protected virtual void Update()
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
    }
}

