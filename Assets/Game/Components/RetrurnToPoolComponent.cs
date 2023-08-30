using Game.Unitls;
using UnityEngine;

namespace Game.Components
{
    public class RetrurnToPoolComponent : MonoBehaviour
    {
        public ObjectPool Pool;

        private void OnDisable()
        {
            Pool._objectsPool.Add(gameObject);
        }
    }
}