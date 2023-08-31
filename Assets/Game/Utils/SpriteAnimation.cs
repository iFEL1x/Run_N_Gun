using UnityEngine;

namespace Game.Unitls
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class SpriteAnimation : MonoBehaviour
    {
        
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] [Range(1, 30)] private int _frameRate = 10;
        
        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentFrame;
        private float _nextFrameTime;
        
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secondsPerFrame = 1f / _frameRate;

            StartAnimation();
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            _currentFrame = 0;
        }
        
        void OnEnable()
        {
            StartAnimation();
        }
        
        private void Update()
        {
            if (_currentFrame >= _sprites.Length)
                gameObject.SetActive(false);

            if (_nextFrameTime > Time.time) return;
         
            _renderer.sprite = _sprites[_currentFrame];

            _nextFrameTime += _secondsPerFrame;
            _currentFrame++;
        }
    }
}