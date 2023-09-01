using System;
using UnityEngine;

namespace Game.Components
{
    public class RotationObjectComponent : MonoBehaviour, IActivatable
    {
        [Tooltip("If value is set 0, the object will rotate infinitely")]
        [SerializeField] private float _timerDuration;
        [SerializeField] private float _multiple;
        
        private void Update()
        {
            if(_timerDuration < Time.time && _timerDuration != 0f) return;
            
            transform.Rotate(Vector3.forward * -(_multiple * Time.deltaTime));
        }

        public void Activate()
        {
            this.enabled = true;
        }
    }
}