using System.Collections;
using UnityEngine;
using Spine.Unity;
using Game.Creatures;
using Game.Interface;
using Game.Components;

namespace Game.Buttons
{
    public class ButtonPlay : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private ChangeSpriteColor[] _changeColorArr;
        [SerializeField] private RotationObjectComponent[] _rotationArr;
        private Player _player;
        private SkeletonAnimation _playerAnimation;
        private Animator _animation;

        private void Awake()
        {
            _animation = GetComponent<Animator>();
            _player = FindObjectOfType<Player>();
            _playerAnimation = _player.GetComponentInChildren<SkeletonAnimation>();
            _playerAnimation.AnimationState.SetAnimation(0, "idle", true);
        }

        public void StartGame()
        {
            _player.enabled = true;
            _menu.SetActive(true);
            _playerAnimation.AnimationState.SetAnimation(0, "walk", true);

            EnableComponent(_changeColorArr);
            EnableComponent(_rotationArr);

            StartCoroutine(ButtonDisabled());
        }

        private void EnableComponent<T>(T[] components) where T : MonoBehaviour, IActivatable
        {
            foreach (var component in components)
            {
                component.Activate();
            }
        }

        private IEnumerator ButtonDisabled()
        {
            _animation.SetTrigger("disappear");
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }
}