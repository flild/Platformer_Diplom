using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using Zenject;

namespace Platformer.Shop
{
    public class ShopVM
    {

        private StatsUpgradeVM _statsUpVM; 
        private ShopModel _shop;

        public ReactiveProperty<int> CoinView = new();


        public ReactiveProperty<float> MaxHealthBuyCostView = new();
        public ReactiveProperty<float> DamageBuyCostView = new();
        public ReactiveProperty<float> BlockDamageBuyCostView = new();
        public ReactiveProperty<float> SpeedBuyCostView = new();

        public ReactiveProperty<float> LightingBuyCostView = new();
        public ReactiveProperty<float> HealingBuyCostView = new();
        public ReactiveProperty<float> CometBuyCostView = new();
        public ReactiveProperty<float> BubbleBuyCostView = new();

        public ReactiveProperty<int> LightingLevelView = new();
        public ReactiveProperty<int> HealingLevelView = new();
        public ReactiveProperty<int> CometLevelView = new();
        public ReactiveProperty<int> BubbleLevelView = new();

        public ShopVM(ShopModel shop, StatsUpgradeVM statsUpVM)
        {
            this._statsUpVM = statsUpVM;
            this._shop = shop;
            SubscribeInit();
            Init();
        }
        public void Init()
        {
            CoinView.Value = _shop.Coin.Value;
            LightingLevelView.Value = _shop.LightingLevel.Value;
            HealingLevelView.Value = _shop.HealingLevel.Value;
            CometLevelView.Value = _shop.CometLevel.Value;
            BubbleLevelView.Value = _shop.BubbleLevel.Value;

            RecalculateHealthCost(_statsUpVM.MaxHealthView.Value);
            RecalculateDamageCost(_statsUpVM.DamagevView.Value);
            RecalculateDamageBlockCost(_statsUpVM.BlockDamageView.Value);
            RecalculateSpeedCost(_statsUpVM.SpeedView.Value);

        }
        public void SubscribeInit()
        {

            _shop.Coin.OnChanged += OnCoinChange;
            _statsUpVM.MaxHealthView.OnChanged += RecalculateHealthCost;
            _statsUpVM.DamagevView.OnChanged += RecalculateDamageCost;
            _statsUpVM.BlockDamageView.OnChanged += RecalculateDamageBlockCost;
            _statsUpVM.SpeedView.OnChanged += RecalculateSpeedCost;

            LightingLevelView.OnChanged += RecalculateLightingCost;
            HealingLevelView.OnChanged += RecalculateHealingCost;
            CometLevelView.OnChanged += RecalculateCometCost;
            BubbleLevelView.OnChanged += RecalculateBubbleCost;

            _shop.LightingLevel.OnChanged += OnChangeLightingLevel;
            _shop.HealingLevel.OnChanged += OnChangeHealingLevel;
            _shop.CometLevel.OnChanged += OnChangeCometLevel;
            _shop.BubbleLevel.OnChanged += OnChangeBubbleLevel;
        }
        #region Cost change recalculation
        private void RecalculateHealthCost(float MaxHealthValue)
        {
            MaxHealthBuyCostView.Value = MaxHealthValue * _shop.MaxHealthCostStep;
        }
        private void RecalculateDamageCost(float Damagevalue)
        {
            DamageBuyCostView.Value = Damagevalue * _shop.DamageCostStep;
        }
        private void RecalculateDamageBlockCost(float DamageBlockValue)
        {
            BlockDamageBuyCostView.Value = DamageBlockValue * _shop.DamageBlockCostStep;
        }
        private void RecalculateSpeedCost(float SpeedValue)
        {
            SpeedBuyCostView.Value = SpeedValue * _shop.SpeedCostStep;
        }

        //skills
        private void RecalculateLightingCost(int lightingLevel)
        {
            if (lightingLevel < 1)
                lightingLevel = 1;
            LightingBuyCostView.Value = lightingLevel * _shop.LightingLevelCostStep;
        }
        private void RecalculateHealingCost(int HealingLevel)
        {
            if (HealingLevel < 1)
                HealingLevel = 1;
            HealingBuyCostView.Value = HealingLevel * _shop.HealingLevelCostStep;
        }
        private void RecalculateCometCost(int CometLevel)
        {
            if (CometLevel < 1)
                CometLevel = 1;
            CometBuyCostView.Value = CometLevel * _shop.CometLevelCostStep;
        }
        private void RecalculateBubbleCost(int BubbleLevel)
        {
            if (BubbleLevel < 1)
                BubbleLevel = 1;
            BubbleBuyCostView.Value = BubbleLevel * _shop.BubleLevelCostStep;
        }
        #endregion

        //stats buy
        #region Buy functions
        public void HealthBuy()
        {
            CoinView.Value -= (int)MaxHealthBuyCostView.Value;
            _statsUpVM.MaxHealthView.Value += _shop.MaxHealthStep;

        }
        public void DamageBuy()
        {
            CoinView.Value -= (int)DamageBuyCostView.Value;
            _statsUpVM.DamagevView.Value += _shop.DamageStep;

        }
        public void BlockDamageBuy()
        {
            CoinView.Value -= (int)BlockDamageBuyCostView.Value;
            _statsUpVM.BlockDamageView.Value += _shop.DamageBlockStep;

        }
        public void SpeedBuy()
        {
            CoinView.Value -= (int)SpeedBuyCostView.Value;
            _statsUpVM.SpeedView.Value += _shop.SpeedStep;

        }
        //skills buy
        public void LightingUpgrade()
        {
            CoinView.Value -= (int)LightingBuyCostView.Value;
            LightingLevelView.Value += 1;
        }
        public void HealingUpgrade()
        {
            CoinView.Value -= (int)HealingBuyCostView.Value;
            HealingLevelView.Value += 1;
        }
        public void CometUpgrade()
        {
            CoinView.Value -= (int)CometBuyCostView.Value;
            CometLevelView.Value += 1;
        }
        public void BubbleUpgrade()
        {
            CoinView.Value -= (int)BubbleBuyCostView.Value;

             BubbleLevelView.Value += 1;
        }
        #endregion 
        private void OnChangeLightingLevel(int value)
        {
            LightingLevelView.Value = value;
        }
        private void OnChangeHealingLevel(int value)
        {
            HealingLevelView.Value = value;
        }
        private void OnChangeCometLevel(int value)
        {
            CometLevelView.Value = value;
        }
        private void OnChangeBubbleLevel(int value)
        {
            BubbleLevelView.Value = value;
        }
        private void OnCoinChange(int value)
        {
            CoinView.Value = value;
        }


        public void AcceptChanges()
        {
            _statsUpVM.AcceptUpgrade();
            _shop.AcceptUpgrades();
            _shop.LightingLevel.Value = LightingLevelView.Value;
            _shop.HealingLevel.Value = HealingLevelView.Value;
            _shop.CometLevel.Value = CometLevelView.Value;
            _shop.BubbleLevel.Value = BubbleLevelView.Value;
            _shop.Coin.Value = CoinView.Value;
        }
        public void CancelChanges()
        {
            _statsUpVM.CancelUpgrade();
            LightingLevelView.Value = _shop.LightingLevel.Value;
            HealingLevelView.Value = _shop.HealingLevel.Value;
            CometLevelView.Value = _shop.CometLevel.Value;
            BubbleLevelView.Value = _shop.BubbleLevel.Value;
            CoinView.Value = _shop.Coin.Value;
        }

    }
 
}