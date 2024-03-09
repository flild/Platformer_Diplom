using Platformer.Units.PlayerSpace;
using System;
using UnityEngine;

namespace Platformer.UI.Popup
{
    public class DeathPopup : PopupContentBase
    {
        private GameManager _gameManager;
        private Player _player;
        public override event Action HidePopup;
        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _player = FindObjectOfType<Player>();
        }
        public void LoadGameBtn_U()
        {
            _gameManager.LoadGame();
            _player.PlayerAlive();
            HidePopup?.Invoke();
        }
        public void NewGameBtn_U()
        {
            _gameManager.StartNewGame();
            _player.PlayerAlive();
            HidePopup?.Invoke();
        }
    }
}

