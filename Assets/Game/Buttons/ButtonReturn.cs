using UnityEngine;

namespace Game.Buttons
{
    public class ButtonReturn : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private Animator _animationMainMenu;


        public void ActivateMenu()
        {
            Time.timeScale = 1;
            _menu.SetActive(true);
            _animationMainMenu.SetTrigger("exit");
        }
    }
}