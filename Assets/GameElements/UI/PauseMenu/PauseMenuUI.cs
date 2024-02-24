using UnityEngine;

namespace Platformer.UI
{
    public class PauseMenuUI : MonoBehaviour, IClosebleWindow
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
        public void SaveGameBtn_U()
        {
            _pauseMenu.SaveGameBtn();
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


