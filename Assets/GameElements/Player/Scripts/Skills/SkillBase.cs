using Platformer.Extensions;

using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public abstract class SkillBase
    {
        public float Damage;
        public bool IsBlocked = true;
        public bool IsUpgrade { get
            {
                return Level > 0 ? true : false;
            } }
        public int Level = 0;
        protected SkillType _type;
        //
        protected Transform _skillParent;
        protected float _cooldownDuration;
        protected SkillViewBase _skillView;

        public virtual void MainAction()
        {
            Debug.Log("Use skill" + _type);
            IsBlocked = true;
            _skillView.StartCooldown(_cooldownDuration);
            _skillView.EndCooldown += OnEndCoolDown;

        }
        private void OnEndCoolDown()
        {
            _skillView.EndCooldown -= OnEndCoolDown;
            IsBlocked = false;
        }
        public SkillType getType()
        {
            return _type;
        }
    }
}
