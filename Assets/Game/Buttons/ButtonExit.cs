using UnityEngine;

namespace Game.Buttons
{
    public class ButtonExit : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}