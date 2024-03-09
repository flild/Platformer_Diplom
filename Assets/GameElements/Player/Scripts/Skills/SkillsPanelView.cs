using AYellowpaper.SerializedCollections;
using Platformer.Extensions;
using UnityEngine.UI;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class SkillsPanelView: MonoBehaviour
    {
        [SerializeField]
        private SkillManager _skillManager;
        [SerializedDictionary("SkillType", "Image")]
        public SerializedDictionary<SkillType, Image> _skillsMap;

        private void Awake()
        {
            _skillManager.ChangeSkillsLevel += OnSkillsLevelChange;
        }
        private void OnDestroy()
        {
            _skillManager.ChangeSkillsLevel -= OnSkillsLevelChange;
        }
        private void OnSkillsLevelChange(SkillType type)
        {
            var level = _skillManager.GetSkillLevel(type);
            if (level > 0)
            {
                _skillsMap[type].color = new Color(255, 255, 255, 1);
            }
        }
    }
}
