using System.Collections;
using UnityEngine;
using Game.Unitls;
using Spine;
using UnityEngine.UI;
using Animation = UnityEngine.Animation;

namespace Game.Creatures
{
    public class Player : Creature
    {
        [HideInInspector] public Cooldown shootReady;
        [SerializeField] private ParticleSystem _shootParticle;
        [SerializeField] private Animator _buttonRestart;
        private string _currentAnimation;
        private float _defaultSpeed;

        private void Start()
        {
            shootReady = GetComponent<Cooldown>();
            _currentAnimation = animation.AnimationState.GetCurrent(0).Animation.Name;
            _defaultSpeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Enemy"))
            {
                speed = 0;
                animation.AnimationState.SetAnimation(0, "loose", false);
                GetComponent<BoxCollider2D>().enabled = false;
                this.enabled = false;
                
                _buttonRestart.SetTrigger("restart");
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
                SetAnimationShoot("shoot");
                shootReady.Reset();
                
                yield return new WaitForSeconds(0.35f);
                _shootParticle.gameObject.SetActive(true);
            }
        }

        public void ShootFail()
        {
            if (_currentAnimation == "walk")
                SetAnimationShoot("shoot_fail");
        }
        
        private void SetAnimationShoot(string animationName)
        {
            speed = 0f;

            var currentTrack = animation.AnimationState.SetAnimation(0, animationName, false);
            _currentAnimation = animationName;
            
            currentTrack.Complete += SetAnimationDefault;
        }

        private void SetAnimationDefault(TrackEntry trackEntry)
        {
            animation.AnimationState.SetAnimation(0, "walk", true);
            _currentAnimation = "walk";
            
            speed = _defaultSpeed;
        }
    }
}