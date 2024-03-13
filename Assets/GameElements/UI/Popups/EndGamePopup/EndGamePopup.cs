using System;
using UnityEngine;

namespace Platformer.UI.Popup
{
    public class EndGamePopup : PopupContentBase
    {
        private GameManager _gameManager;
        public override event Action HidePopup;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        public void ExitBtn_U()
        {
            HidePopup?.Invoke();
#if UNITY_EDITOR
            Debug.Break();
#else
            Application.Quit();
#endif
        }
        public void NewGameBtn_U()
        {
            HidePopup?.Invoke();
            _gameManager.StartNewGame();

        }
    }
}
