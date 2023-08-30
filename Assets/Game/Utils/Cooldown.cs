using UnityEngine;

namespace Game.Unitls
{
    public class Cooldown : MonoBehaviour
    {
        [SerializeField] [Range(1, 5)]private float _timeCooldown;
        private float _timesUp;
        public bool IsReady => _timesUp <= Time.time;

        private void Start()
        {
            if (_timeCooldown <= 0)
                _timeCooldown = 1.5f;
        }

        public void Reset()
        {
            _timesUp = Time.time + _timeCooldown;
        }
    }
}