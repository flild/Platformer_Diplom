﻿using Platformer.Shop;
using Platformer.Units.PlayerSpace;
using Zenject;
using UnityEngine;
using Platformer.UI;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class UIManager:MonoBehaviour
    {
        //Shop
        private ShopModel _shop;
        private ShopVM _shopVM;
        private StatsUpgradeVM _statsVM;
        [Inject]
        private Player _player;
        [Inject]
        private CoinManager _coinManager;
        [Inject]
        private GameManager _gameManager;
        [SerializeField]
        private ShopUI _shopUI;
        [SerializeField]
        private PauseMenuUI _pauseUI;
        [SerializeField]
        private StatsUpgradeUI _statsUI;
        [SerializeField]
        private SkillManager _skillManager;
        private PlayerController _controller;

        private IClosebleWindow ActiveWindow;
        private void Start()
        {
            //Shop
            _shop = new ShopModel(_coinManager, _skillManager);
            _statsVM = new StatsUpgradeVM(_player.Stats);
            _shopVM = new ShopVM(_shop, _statsVM);
            _shopUI.Init(_shopVM);
            _statsUI.Init(_statsVM);

            _pauseUI.Init(new PauseMenu(_gameManager, this));

        }
        private void OnEnable()
        {
            _controller = new PlayerController();
            _controller.Enable();
            _controller.UI.Shop.performed += OpenShop;
            _controller.UI.CloseCurrentWindow.performed += OpenPauseMenu;
        }
        private void OnDisable()
        {
            _controller.Disable();
            _controller.UI.Shop.performed -= OpenShop;
            _controller.UI.CloseCurrentWindow.performed -= OpenPauseMenu;
        }

        private void OpenShop(InputAction.CallbackContext context)
        {
            if(_shopUI.gameObject.active)
            {
                _shopUI.gameObject.SetActive(false);
                ActiveWindow = null;
            }
            else
            {
                _shopUI.gameObject.SetActive(true);
                ActiveWindow = _shopUI;
            }
        }
        private void OpenPauseMenu(InputAction.CallbackContext context)
        {
            Time.timeScale = 0;
            if (ActiveWindow == null)
            { 
                _pauseUI.gameObject.SetActive(true);
                ActiveWindow = _pauseUI;
            }
            else
            {
                CloseCurrentOpenWindow();
            }
        }
        public void CloseCurrentOpenWindow()
        {
            if (ActiveWindow != null)
            {
                ActiveWindow.gameObject.SetActive(false);
                Time.timeScale = 1;
            }   
            ActiveWindow = null;
        }
    }
}
