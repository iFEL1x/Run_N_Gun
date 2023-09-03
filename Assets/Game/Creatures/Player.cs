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
        [SerializeField] private Animator _buttonRestart;
        [SerializeField] private Animator _buttonEnd;
        private string _currentNameAnimation;
        private float _defaultSpeed;

        private void Start()
        {
            shootReady = GetComponent<Cooldown>();
            _currentNameAnimation = animation.AnimationState.GetCurrent(0).Animation.Name;
            _defaultSpeed = speed;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Enemy"))
            {
                GetComponent<BoxCollider2D>().enabled = false;
                speed = 0;
                animation.AnimationState.SetAnimation(0, "loose", false);
                
                _buttonRestart.SetTrigger("enter");
                enabled = false;
            }
            else if (collider.CompareTag("Finish"))
            {
                StartCoroutine(Finish());
            }
        }

        public IEnumerator Shoot()
        {
            if (_currentNameAnimation != "shoot")
            {
                SetAnimationShoot("shoot");
                shootReady.Reset();
                
                yield return new WaitForSeconds(0.35f);
                _shootParticle.gameObject.SetActive(true);
            }
        }

        public void ShootFail()
        {
            if (_currentNameAnimation == "walk")
                SetAnimationShoot("shoot_fail");
        }
        
        private void SetAnimationShoot(string animationName)
        {
            speed = 0f;

            var currentTrack = animation.AnimationState.SetAnimation(0, animationName, false);
            _currentNameAnimation = animationName;
            
            currentTrack.Complete += SetAnimationWalk;
        }

        private void SetAnimationWalk(TrackEntry trackEntry)
        {
            animation.AnimationState.SetAnimation(0, "walk", true);
            _currentNameAnimation = "walk";
            
            speed = _defaultSpeed;
        }
        
        private IEnumerator Finish()
        {
            speed *= 2f;
            animation.AnimationState.SetAnimation(0, "run", true);
            
            yield return new WaitForSeconds(5f);
            
            _buttonEnd.SetTrigger("enter");
            gameObject.SetActive(false);
        }
    }
}