using System;
using UnityEngine;

namespace Game.Components
{
    public class ParalaxEffectComponent : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField, Range(-1f, 1f)] private float _parallaxStrenght = 0.1f;
        
        private Vector3 _startPositin;


        private void Awake()
        {
            _startPositin = _followTarget.position;
        }

        private void Update()
        {
            var delta = _followTarget.position - _startPositin;

            _startPositin = _followTarget.position;
            transform.position += delta * _parallaxStrenght;
        }
    }
}