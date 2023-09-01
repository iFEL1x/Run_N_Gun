using UnityEngine;

namespace Game.Components
{
    public class ChangeSpriteColor : MonoBehaviour, IActivatable
    {
        [SerializeField] private float _timeLeft;
        [SerializeField] private Color _newColor;
        private SpriteRenderer _spriteRender;

        private void Start()
        {
            _spriteRender = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _spriteRender.color = Color.Lerp(_spriteRender.color, _newColor, _timeLeft * Time.deltaTime);
        }

        public void Activate()
        {
            this.enabled = true;
        }
    }
}