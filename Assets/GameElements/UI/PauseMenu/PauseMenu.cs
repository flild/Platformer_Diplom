
using UnityEngine;

namespace Platformer.UI
{
    public class PauseMenu
    {
        private GameManager _gameManager;

        public PauseMenu(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void ResumeGameBtn()
        {

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
