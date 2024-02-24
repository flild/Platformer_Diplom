using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.UI.StartMenu
{
    public class StartMenuVM
    {

        public void StartNewGameBtn()
        {
            SceneManager.LoadScene(1);
        }
        public void LoadGameBtn()
        {

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
