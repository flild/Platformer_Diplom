using Platformer.Extensions;
using Platformer.Shop;
using Zenject;

namespace Platformer.Units.PlayerSpace
{
    public class StatsUpgradeVM
    {
        private Stats _stats;
        public ReactiveProperty<float> MaxHealthView = new();
        public ReactiveProperty<float> DamagevView = new();
        public ReactiveProperty<float> BlockDamageView = new();
        public ReactiveProperty<float> SpeedView = new();

        public StatsUpgradeVM(Stats stats)
        {
            _stats = stats;
            Init();
            MaxHealthView.Value = _stats.MaxHealth.Value;
            _stats.MaxHealth.OnChanged += OnChangeMaxHealth;
            _stats.Damage.OnChanged += OnChangeDamage;
            _stats.BlockDamage.OnChanged += OnChangeBlockDamage;
            _stats.Speed.OnChanged += OnChangespeed;
        }
        private void Init()
        {
            MaxHealthView.Value = _stats.MaxHealth.Value;
            DamagevView.Value = _stats.Damage.Value;
            BlockDamageView.Value = _stats.BlockDamage.Value;
            SpeedView.Value = _stats.Speed.Value;
        }
        public void AcceptUpgrade()
        {
            //берем все статы и приравниваем их к вьюшным статам
            _stats.MaxHealth.Value = MaxHealthView.Value;
            _stats.Damage.Value = DamagevView.Value;
            _stats.BlockDamage.Value = BlockDamageView.Value;
            _stats.Speed.Value = SpeedView.Value;

        }
        public void CancelUpgrade()
        {
            //все вьюшные статы приравниваем к статам
            MaxHealthView.Value = _stats.MaxHealth.Value;
            DamagevView.Value = _stats.Damage.Value;
            BlockDamageView.Value = _stats.BlockDamage.Value;
            SpeedView.Value = _stats.Speed.Value;
        }
        

        #region Reaction on change value in stats
        private void OnChangeMaxHealth(float value)
        {
            MaxHealthView.Value = value;
        }
        private void OnChangeDamage(float value)
        {
            DamagevView.Value = value;
        }
        private void OnChangeBlockDamage(float value)
        {
            BlockDamageView.Value = value;
        }
        private void OnChangespeed(float value)
        {
            SpeedView.Value = value;
        }
        #endregion

    }
}
