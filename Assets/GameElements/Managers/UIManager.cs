using Platformer.Shop;
using Platformer.Units.PlayerSpace;
using Zenject;
using UnityEngine;

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
        [SerializeField]
        private ShopUI _shopUI;
        [SerializeField]
        private StatsUpgradeUI _statsUI;
        [SerializeField]
        private SkillManager _skillManager;
        private void Start()
        {
            //Shop
            _shop = new ShopModel(_coinManager, _skillManager);
            _statsVM = new StatsUpgradeVM(_player.Stats);
            _shopVM = new ShopVM(_shop, _statsVM);
            _shopUI.Init(_shopVM);
            _statsUI.Init(_statsVM);

        }
    }
}
