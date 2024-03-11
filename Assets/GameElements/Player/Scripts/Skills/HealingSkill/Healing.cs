using Platformer.Extensions;
using Platformer.Units.PlayerSpace.Skill;
using System.Collections;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class Healing : SkillBase
    {

        private float HealValue = 1f;
        private Player _player;
        private float _healingValueTick;
        private float _healTickDelay;

        public Healing(HealingView view, Player player)
        {
            _skillView = view;
            _player = player;
            Init();
            _player = player;
        }
        public void Init()
        {
            Damage = 0;
            Level = 0;
            _type = SkillType.Heal;
            _healingValueTick = 0.5f;
            _healTickDelay = 0.5f;
            _cooldownDuration = 15;
        }
        public override void MainAction()
        {
            base.MainAction();
            CoroutineManager.StartRoutine(HealingProcces());
        }
        private IEnumerator HealingProcces()
        {
            _skillView.gameObject.SetActive(true);
            float completedHeal = 0f;
            while(completedHeal< HealValue * Level)
            {
                _player.Stats.Health.Value += _healingValueTick;
                completedHeal += _healingValueTick;
                yield return new WaitForSeconds(_healTickDelay);
            }
            yield return new WaitForSeconds(_healTickDelay);
            _skillView.gameObject.SetActive(false);
        }
    }
}
