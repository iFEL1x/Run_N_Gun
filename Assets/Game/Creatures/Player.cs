using System.Collections;
using UnityEngine;
using Game.Unitls;
using Spine;
using Spine.Unity;

namespace Game.Creatures
{
    public class Player : Creature
    {
        [HideInInspector] public Cooldown shootReady;
        [SerializeField] private ParticleSystem _shootParticle;
        [SerializeField] private SkeletonAnimation _animation;
        private bool _playerLoose;
        private string _curentAnimation;
        private string _defaultAnimation;
        private float _defaultSpeed;

        private void Start()
        {
            shootReady = GetComponent<Cooldown>();
            _defaultAnimation = _animation.AnimationState.GetCurrent(0).Animation.Name;
            _curentAnimation = _defaultAnimation;
            _defaultSpeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Enemy"))
            {
                speed = 0;
                _animation.AnimationState.SetAnimation(0, "loose", false);
                GetComponent<BoxCollider2D>().enabled = false;
                
                _playerLoose = true;
            }
            else if (collider.CompareTag("Finish"))
            {
                speed *= 1.5f;
                _animation.AnimationState.SetAnimation(0, "run", true);
            }
        }
        
        public IEnumerator Shoot()
        {
            if (_curentAnimation != "shoot")
            {
                SetAnimation( 0f, "shoot");
                shootReady.Reset();
                
                yield return new WaitForSeconds(0.35f);
                _shootParticle.gameObject.SetActive(true);
            }
        }

        public void ShootFail()
        {
            if (_curentAnimation == _defaultAnimation)
                SetAnimation( 0f, "shoot_fail");
        }
        
        private void SetAnimation(float playerSpeed, string animation)
        {
            speed = playerSpeed;
            _curentAnimation = animation;
            
            var currentTrack = _animation.AnimationState.SetAnimation(0, animation, false);
            currentTrack.Complete += SetDefaultAnimation;
        }

        private void SetDefaultAnimation(TrackEntry trackEntry)
        {
            _animation.AnimationState.SetAnimation(0, _defaultAnimation, true);
            _curentAnimation = _defaultAnimation;
            speed = _defaultSpeed;
        }
    }
}