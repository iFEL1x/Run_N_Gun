using System.Collections.Generic;
using Game.Components;
using Game.Creatures;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Unitls
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToPool;
        [SerializeField] private int _sizePool;
        public List<GameObject> _objectsPool;

        private void Start()
        {
            CreatePool();
        }

        private void CreatePool()
        {
            _objectsPool = new List<GameObject>();
            for (int i = 0; i < _sizePool; i++)
            {
                var tmpObj = Instantiate(_objectToPool, transform.position, quaternion.identity);
                tmpObj.SetActive(false);
                tmpObj.AddComponent<RetrurnToPoolComponent>().Pool = this;
                _objectsPool.Add(tmpObj);
            }
        }

        public void SpawnObject(Transform parent, Vector3 transform, float speed)
        {
            GameObject tmpObj;
            
            if (_objectsPool.Count != 0)
            {
                tmpObj = _objectsPool[0];
                _objectsPool.RemoveAt(0);
            }
            else
            {
                tmpObj = Instantiate(_objectToPool);
                Debug.LogWarning($"Object {tmpObj.name} has been created, pool is empty, need to increase the pool.");
            }
            
            tmpObj.GetComponent<Creature>().speed = speed;
            tmpObj.transform.position = transform;
            tmpObj.transform.parent = parent;
            tmpObj.SetActive(true);
        }
    }
}