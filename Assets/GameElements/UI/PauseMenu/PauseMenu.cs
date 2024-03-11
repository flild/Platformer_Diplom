
using UnityEngine;

namespace Platformer.UI
{
    public class PauseMenu
    {
        private GameManager _gameManager;
        private UIManager _UImanager;

        public PauseMenu(GameManager gameManager, UIManager uiManager)
        {
            _gameManager = gameManager;
            _UImanager = uiManager;
        }
        public void ResumeGameBtn()
        {
            _UImanager.CloseCurrentOpenWindow();
        }

        public void SaveGameBtn()
        {
            _gameManager.SaveGame();
        }

        public void LoadGameBtn()
        {
            _gameManager.LoadGame();
        }

        public void SettingsBtn()
        {

        }

        public void ExitBtn()
        {
#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif
        }


    }
}
