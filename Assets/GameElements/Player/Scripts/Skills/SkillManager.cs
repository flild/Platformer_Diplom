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
        [Inject]
        Player player;
        public Action<SkillType> ChangeSkillsLevel;

        private void Awake()
        {
            _skillsMap = new Dictionary<SkillType, SkillBase>();
            _skillsMap.Add(SkillType.Lighting, new Lighting(_lightingView));
            _skillsMap.Add(SkillType.Heal, new Healing(_healingView, player));
            _skillsMap.Add(SkillType.IceComet, new IceComet());
            _skillsMap.Add(SkillType.Bubble, new IceComet());
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
        public uint GetSkillLevel(SkillType type)
        {
            return _skillsMap[type].Level;
        }
        public void ChangeSkillLevel(SkillType type, uint value)
        {
            _skillsMap[type].Level = value;
            ChangeSkillsLevel?.Invoke(type);
        }
    }
}
