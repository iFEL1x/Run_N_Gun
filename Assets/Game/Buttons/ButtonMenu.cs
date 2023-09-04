using UnityEngine;

namespace Game.Buttons
{
    public class ButtonMenu : MonoBehaviour
    {
        [SerializeField] private Animator _animationMainMenu;

        public void ActivateMainMenu()
        {
            gameObject.SetActive(false);
            _animationMainMenu.SetTrigger("enter");
        }
    }
}