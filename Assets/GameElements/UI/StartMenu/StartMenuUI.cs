using UnityEngine;

namespace Platformer.UI.StartMenu
{
    public class StartMenuUI : MonoBehaviour
    {
        PauseMenu _pauseMenu;

        public void Init(PauseMenu vm)
        {
            _pauseMenu = vm;
        }    
        public void ResumeGameBtn_U()
        {
            _pauseMenu.ResumeGameBtn();
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

