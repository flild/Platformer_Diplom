using UnityEngine;
using TMPro;


namespace Platformer.Units.PlayerSpace
{

    public class StatsUpgradeUI: MonoBehaviour
    {
        private StatsUpgradeVM _viewModel;

        [SerializeField]
        private TMP_Text _HealthValueLabel;
        [SerializeField]
        private TMP_Text _DamageValueLabel;
        [SerializeField]
        private TMP_Text _BlockDamageValueLabel;
        [SerializeField]
        private TMP_Text _SpeedValueLabel;

        public void Init(StatsUpgradeVM StatsUpgradeVM)
        {
            _viewModel = StatsUpgradeVM;
            _viewModel.MaxHealthView.OnChanged += OnChangeMaxHealth;
            _viewModel.DamagevView.OnChanged += OnChangeDamage;
            _viewModel.BlockDamageView.OnChanged += OnChangeBlockDamage;
            _viewModel.SpeedView.OnChanged += OnChangeSpeed;
        }
        private void OnDestroy()
        {
            _viewModel.MaxHealthView.OnChanged -= OnChangeMaxHealth;
            _viewModel.DamagevView.OnChanged -= OnChangeDamage;
            _viewModel.BlockDamageView.OnChanged -= OnChangeBlockDamage;
            _viewModel.SpeedView.OnChanged -= OnChangeSpeed;
        }

        #region Reaction on change value in VM

        private void OnChangeMaxHealth(float value)
        {
            _HealthValueLabel.text = value.ToString();
        }
        private void OnChangeDamage(float value)
        {
            _DamageValueLabel.text = value.ToString();
        }
        private void OnChangeBlockDamage(float value)
        {
            _BlockDamageValueLabel.text = value.ToString();
        }
        private void OnChangeSpeed(float value)
        {
            _SpeedValueLabel.text = value.ToString();
        }
        #endregion

    }
}


