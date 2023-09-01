using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Buttons
{
    public class ButtonRestart : MonoBehaviour
    {
        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}