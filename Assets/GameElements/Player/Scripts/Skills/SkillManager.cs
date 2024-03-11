using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using Platformer.Units.PlayerSpace.Skill;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Platformer
{
    public class SkillManager : MonoBehaviour
    {
        private Dictionary<SkillType, SkillBase> _skillsMap;
        [SerializeField]
        private LightingView _lightingView;
        [SerializeField]
        private HealingView _healingView;
        [SerializeField]
        private IceCometView _cometView;
        [SerializeField]
        private BubbleView _bubbleView;
        [Inject]
        Player player;
        public Action<SkillType> ChangeSkillsLevel;

        private void Awake()
        {
            _skillsMap = new Dictionary<SkillType, SkillBase>();
            _skillsMap.Add(SkillType.Lighting, new Lighting(_lightingView));
            _skillsMap.Add(SkillType.Heal, new Healing(_healingView, player));
            _skillsMap.Add(SkillType.IceComet, new IceComet(_cometView));
            _skillsMap.Add(SkillType.Bubble, new Bubble(_bubbleView, player.Stats));
        }
        private void Start()
        {
            foreach (SkillType type in (SkillType[])Enum.GetValues(typeof(SkillType)))
            {
                ChangeSkillsLevel?.Invoke(type);
            }
        }
        public void UseSkill(SkillType type)
        {
            _skillsMap[type].MainAction();
        }
        public bool SkillIsUpgrade(SkillType type)
        {
            return _skillsMap[type].IsUpgrade;
        }
        public int GetSkillLevel(SkillType type)
        {
            return _skillsMap[type].Level;
        }
        public bool IsSkillBlocked(SkillType type)
        {
            return _skillsMap[type].IsBlocked;
        }
        public void ChangeSkillLevel(SkillType type, int value)
        {
            if(_skillsMap[type].Level == value)
                return;
            _skillsMap[type].IsBlocked = value > 0 ? false : true;
            _skillsMap[type].Level = value;
            ChangeSkillsLevel?.Invoke(type);
        }
        public SkillsSaveData GetSaveData()
        {
            SkillsSaveData data = new();
            data.LightingLevel = GetSkillLevel(SkillType.Lighting);
            data.HealingLevel = GetSkillLevel(SkillType.Heal);
            data.CometLevel = GetSkillLevel(SkillType.IceComet);
            data.BubbleLevel = GetSkillLevel(SkillType.Bubble);
            return data;
        }
        public void SetSaveData(SkillsSaveData data)
        {
            ChangeSkillLevel(SkillType.Lighting, data.LightingLevel);
            ChangeSkillLevel(SkillType.Heal, data.HealingLevel);
            ChangeSkillLevel(SkillType.IceComet, data.CometLevel);
            ChangeSkillLevel(SkillType.Bubble, data.BubbleLevel);
        }
    }
}
