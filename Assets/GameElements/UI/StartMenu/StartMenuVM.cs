using UnityEngine;
using IJunior.TypedScenes;


namespace Platformer.UI.StartMenu
{
    public class StartMenuVM: MonoBehaviour
    {

        public void StartNewGameBtn()
        {
            Level_1.Load(false);
        }
        public void LoadGameBtn()
        {
            Level_1.Load(true);
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
