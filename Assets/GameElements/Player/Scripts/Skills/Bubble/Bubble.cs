using Platformer.Extensions;
using System.Collections;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class Bubble: SkillBase
    {
        private BubbleView _view;
        private Stats _stats;
        private float _baseDuration;

        public Bubble(BubbleView view, Stats stats)
        {
            _view = view;
            _stats = stats;
            Init();
        }
        private void Init()
        {
            Damage = 0;
            Level = 2;
            _type = SkillType.Bubble;
            _baseDuration = 0.5f;
        }
        public override void MainAction()
        {
            base.MainAction();
            CoroutineManager.StartRoutine(ActivateBuble());
        }
        private IEnumerator ActivateBuble()
        {
            _view.gameObject.SetActive(true);
            _stats.IsBabbled = true;
            yield return new WaitForSeconds(_baseDuration* Level);
            _view.gameObject.SetActive(false);
            _stats.IsBabbled = false;
        }
    }
}
