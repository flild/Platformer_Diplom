using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using Platformer.UI;

namespace Platformer.Shop
{
    public class ShopUI : MonoBehaviour, IClosebleWindow
    {

        [SerializeField]
        private TMP_Text _coinLabelCount;
        //stats cost
        [SerializeField, Space]
        private TMP_Text _healthBuyCostLabel;
        [SerializeField]
        private TMP_Text _damageBuyCostLabel;
        [SerializeField]
        private TMP_Text _blockDamageBuyCostLabel;
        [SerializeField]
        private TMP_Text _speedBuyCostLabel;
        //skills cost
        [SerializeField, Space]
        private TMP_Text _lightingCostLabel;
        [SerializeField]
        private TMP_Text _healingCostLabel;
        [SerializeField]
        private TMP_Text _cometCostLabel;
        [SerializeField]
        private TMP_Text _bubbleCostLabel;
        //skills levels
        [SerializeField]
        private List<Toggle> _lightingLevels;
        [SerializeField]
        private List<Toggle> _healingLevels;
        [SerializeField]
        private List<Toggle> _cometLevels;
        [SerializeField]
        private List<Toggle> _bubbleLevels;

        private ShopVM _ShopVM;


        private Color _UpgradedPointColor = new Color(143, 255, 121, 255);
        private int _maxSkillLevel = 3;


        public void Init(ShopVM shopVM)
        {
            _ShopVM = shopVM;
            _ShopVM.MaxHealthBuyCostView.OnChanged += OnChangeMaxHealthCost;
            _ShopVM.DamageBuyCostView.OnChanged += OnChangeDamageCost;
            _ShopVM.BlockDamageBuyCostView.OnChanged += OnChangeBlockDamageCost;
            _ShopVM.SpeedBuyCostView.OnChanged += OnChangeSpeedCost;

            _ShopVM.LightingBuyCostView.OnChanged += OnChangeLightingCost;
            _ShopVM.HealingBuyCostView.OnChanged += OnChangeHealingCost;
            _ShopVM.CometBuyCostView.OnChanged += OnChangeCometCost;
            _ShopVM.BubbleBuyCostView.OnChanged += OnChangebubbleCost;

            _ShopVM.LightingLevelView.OnChanged += OnChangeLightingLevel;
            _ShopVM.HealingLevelView.OnChanged += OnChangeHealingLevel;
            _ShopVM.CometLevelView.OnChanged += OnChangeCometLevel;
            _ShopVM.BubbleLevelView.OnChanged += OnChangebubbleLevel;

            _ShopVM.CoinView.OnChanged += OnChangeCoinCount;
        }
        private void OnEnable()
        {
            _ShopVM.Init();
    
        }
        #region Buttons
        //stats btn
        public void HealthBuyBtn_U()
        {
            _ShopVM.HealthBuy();
        }
        public void DamageBuyBtn_U()
        {
            _ShopVM.DamageBuy();
        }
        public void BlockDamageBuyBtn_U()
        {
            _ShopVM.BlockDamageBuy();
        }
        public void SpeedBuyBtn_U()
        {
            _ShopVM.SpeedBuy();
        }


        //skills btn
        public void LightingUpgradeBtn_U()
        {
            _ShopVM.LightingUpgrade();
        }
        public void HealingUpgradeBtn_U()
        {
            _ShopVM.HealingUpgrade();
        }
        public void CometUpgradeBtn_U()
        {
            _ShopVM.CometUpgrade();
        }
        public void BubbleUpgradeBtn_U()
        {
            _ShopVM.BubbleUpgrade();
        }

        //control btn
        public void AcceptChangesBtn_U()
        {
            _ShopVM.AcceptChanges();
        }
        public void CancelChangesBtn_U()
        {
            _ShopVM.CancelChanges();
        } 
        #endregion

        #region On Change view value reaction
        //stats
        private void OnChangeMaxHealthCost(float value)
        {
            _healthBuyCostLabel.text = value.ToString();
        }
        private void OnChangeDamageCost(float value)
        {
            _damageBuyCostLabel.text = value.ToString();
        }
        private void OnChangeBlockDamageCost(float value)
        {
            _blockDamageBuyCostLabel.text = value.ToString();
        }
        private void OnChangeSpeedCost(float value)
        {
            _speedBuyCostLabel.text = value.ToString();
        }

        //skills

        private void OnChangeLightingCost(float value)
        {
            _lightingCostLabel.text = value.ToString();
        }
        private void OnChangeHealingCost(float value)
        {
            _healingCostLabel.text = value.ToString();
        }
        private void OnChangeCometCost(float value)
        {
            _cometCostLabel.text = value.ToString();
        }
        private void OnChangebubbleCost(float value)
        {
            _bubbleCostLabel.text = value.ToString();
        }
        private void OnChangeLightingLevel(int value)
        {
            value -= 1;
            for(int i = 0; i < _maxSkillLevel; i++)
            {
                if(i <= value)
                {
                    _lightingLevels[i].isOn = true;
                }
                else
                {
                    _lightingLevels[i].isOn = false;
                }
            }
        }
        private void OnChangeHealingLevel(int value)
        {
            value -= 1;
            for (int i = 0; i < _maxSkillLevel; i++)
            {
                if (i <= value)
                {
                    _healingLevels[i].isOn = true;
                }
                else
                {
                    _healingLevels[i].isOn = false;
                }
            }
        }
        private void OnChangeCometLevel(int value)
        {
            value -= 1;
            for (int i = 0; i < _maxSkillLevel; i++)
            {
                if (i <= value)
                {
                    _cometLevels[i].isOn = true;
                }
                else
                {
                    _cometLevels[i].isOn = false;
                }
            }
        }
        private void OnChangebubbleLevel(int value)
        {
            value -= 1;
            for (int i = 0; i < _maxSkillLevel; i++)
            {
                if (i <= value)
                {
                    _bubbleLevels[i].isOn = true;
                }
                else
                {
                    _bubbleLevels[i].isOn = false;
                }
            }
        }



        private void OnChangeCoinCount(int value)
        {
            _coinLabelCount.text = value.ToString();
        } 
        #endregion
    }
}

