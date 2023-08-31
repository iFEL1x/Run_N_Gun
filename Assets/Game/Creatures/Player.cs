using System.Collections;
using UnityEngine;
using Game.Unitls;
using Spine;

namespace Game.Creatures
{
    public class Player : Creature
    {
        [HideInInspector] public Cooldown shootReady;
        [SerializeField] private ParticleSystem _shootParticle;
        private string _currentAnimation;
        private string _defaultAnimation;
        private float _defaultSpeed;

        private void Start()
        {
            shootReady = GetComponent<Cooldown>();
            _defaultAnimation = animation.AnimationState.GetCurrent(0).Animation.Name;
            _currentAnimation = _defaultAnimation;
            _defaultSpeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Enemy"))
            {
                speed = 0;
                animation.AnimationState.SetAnimation(0, "loose", false);
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (collider.CompareTag("Finish"))
            {
                speed *= 1.5f;
                animation.AnimationState.SetAnimation(0, "run", true);
            }
        }
        
        public IEnumerator Shoot()
        {
            if (_currentAnimation != "shoot")
            {
                SetAnimation( 0f, "shoot");
                shootReady.Reset();
                
                yield return new WaitForSeconds(0.35f);
                _shootParticle.gameObject.SetActive(true);
            }
        }

        public void ShootFail()
        {
            if (_currentAnimation == _defaultAnimation)
                SetAnimation( 0f, "shoot_fail");
        }
        
        private void SetAnimation(float playerSpeed, string animationName)
        {
            speed = playerSpeed;
            _currentAnimation = animationName;
            
            var currentTrack = animation.AnimationState.SetAnimation(0, animationName, false);
            currentTrack.Complete += SetDefaultAnimation;
        }

        private void SetDefaultAnimation(TrackEntry trackEntry)
        {
            animation.AnimationState.SetAnimation(0, _defaultAnimation, true);
            _currentAnimation = _defaultAnimation;
            speed = _defaultSpeed;
        }
    }
}