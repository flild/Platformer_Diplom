using System;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public abstract class SkillViewBase : MonoBehaviour
    {
        [SerializeField]
        private CooldownView _cooldown;
        public event Action EndCooldown;
        

        public void StartCooldown(float _cooldownDuration)
        {
            _cooldown.gameObject.SetActive(true);
            _cooldown.StartCooldown(_cooldownDuration);
            _cooldown.EndCooldown += OnCooldownEnd;
        }
        private void OnCooldownEnd()
        {
            _cooldown.EndCooldown -= OnCooldownEnd;
            EndCooldown?.Invoke();
        }
    }
}

