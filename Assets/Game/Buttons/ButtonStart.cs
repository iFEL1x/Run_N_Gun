using Game.Components;
using UnityEngine;
using Game.Creatures;
using Spine.Unity;

namespace Game.Buttons
{
    public class ButtonStart : MonoBehaviour
    {
        [SerializeField] private ChangeSpriteColor[] _changeColorArr;
        [SerializeField] private ParalaxEffectComponent[] _paralaxArr;
        [SerializeField] private RotationObjectComponent[] _rotationArr;
        private Player _player;
        private SkeletonAnimation _playerAnimation;
        private bool _isPlay;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _playerAnimation = _player.GetComponentInChildren<SkeletonAnimation>();
            _playerAnimation.AnimationState.SetAnimation(0, "idle", true);
        }

        public void StartGame()
        {
            _isPlay = true;
            _player.enabled = true;
            _playerAnimation.AnimationState.SetAnimation(0, "walk", true);

            EnableComponent(_changeColorArr);
            EnableComponent(_paralaxArr);
            EnableComponent(_rotationArr);
            
            gameObject.SetActive(false);
        }

        private void EnableComponent<T>(T[] components) where T : MonoBehaviour, IActivatable
        {
            foreach (var component in components)
            {
                component.Activate();
            }
        }
    }
}