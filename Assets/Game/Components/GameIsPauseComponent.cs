using UnityEngine;

namespace Game.Components
{
    public class GameIsPauseComponent : MonoBehaviour
    {
        public void PauseGame()
        {
            Time.timeScale = 0;
        }
    }
}