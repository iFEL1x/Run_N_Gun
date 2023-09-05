using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Buttons
{
    public class ButtonRestart : MonoBehaviour
    {
        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}