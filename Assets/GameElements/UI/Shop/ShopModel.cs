
using Platformer.Extensions;

namespace Platformer.Shop
{
    public class ShopModel
    {
        private CoinManager _coinManager;
        private SkillManager _skillManager;
        //todo превратить это в dictinary
        public uint MaxHealthCostStep = 3;
        public uint MaxHealthStep = 1;
        public uint DamageCostStep = 5;
        public uint DamageStep = 1;
        public uint DamageBlockCostStep = 4;
        public float DamageBlockStep = 0.5f;
        public uint SpeedCostStep = 5;
        public uint SpeedStep = 1;

        public int LightingLevelCostStep = 150;
        public int HealingLevelCostStep = 50;
        public int CometLevelCostStep = 100;
        public int BubleLevelCostStep = 100;

        public ReactiveProperty<uint> LightingLevel = new();
        public ReactiveProperty<uint> HealingLevel = new();
        public ReactiveProperty<uint> CometLevel = new();
        public ReactiveProperty<uint> BubbleLevel = new();

        public ReactiveProperty<int> Coin = new();

        public ShopModel(CoinManager coinManager, SkillManager skillManager)
        {
            _coinManager = coinManager;
            _skillManager = skillManager;

            Init();
        }
        public void Init()
        {
            Coin.Value = _coinManager.GetPlayerCoinCount();
            LightingLevel.Value = _skillManager.GetSkillLevel(SkillType.Lighting);
            HealingLevel.Value = _skillManager.GetSkillLevel(SkillType.Heal);
            CometLevel.Value = _skillManager.GetSkillLevel(SkillType.IceComet);
            BubbleLevel.Value = _skillManager.GetSkillLevel(SkillType.Bubble);
        }
        public void AcceptUpgrades()
        {
            _coinManager.ChangeCoinValue(Coin.Value);
            _skillManager.ChangeSkillLevel(SkillType.Lighting, LightingLevel.Value);
            _skillManager.ChangeSkillLevel(SkillType.Heal, HealingLevel.Value);
            _skillManager.ChangeSkillLevel(SkillType.IceComet, CometLevel.Value);
            _skillManager.ChangeSkillLevel(SkillType.Bubble, BubbleLevel.Value);
        }

    }
}


