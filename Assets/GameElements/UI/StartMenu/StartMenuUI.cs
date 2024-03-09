using UnityEngine;

namespace Platformer.UI.StartMenu
{
    public class StartMenuUI : MonoBehaviour
    {
        [SerializeField]
        private StartMenuVM _pauseMenu;

        private void Awake()
        {
            _pauseMenu ??= GetComponent<StartMenuVM>();
        }

        public void Init(StartMenuVM vm)
        {
            _pauseMenu = vm;
        }    
        public void StartNewGameBtn_U()
        {
            _pauseMenu.StartNewGameBtn();
        }
        public void LoadGameBtn_U()
        {
            _pauseMenu.LoadGameBtn();
        }
        public void SettingsBtn_U()
        {
            _pauseMenu.SettingsBtn();
        }
        public void ExitBtn_U()
        {
            _pauseMenu.ExitBtn();
        }
    }
}

