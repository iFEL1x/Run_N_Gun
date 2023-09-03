using Game.Unitls;
using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private string _nameObjectCollision;
        [SerializeField] private float _positionY;
        [SerializeField] private float _positionZ;
        [SerializeField] [Range(-1, -10)] private float _speed;
        private Transform _parent;
        private Vector3 _transform;
        private ObjectPool _pool;

        private void Start()
        {
            _pool = FindObjectOfType<ObjectPool>();
            _parent = transform.parent;
            _transform = transform.position;
            _transform.y = _positionY;
            _transform.z = _positionZ;

            if (_speed >= 0)
                _speed = -3;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(_nameObjectCollision))
            {
                _pool.SpawnObject(_parent, _transform, _speed);
            }
        }
    }
}