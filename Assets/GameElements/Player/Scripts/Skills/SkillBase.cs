using Platformer.Extensions;

using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public abstract class SkillBase
    {
        public float Damage;
        public bool IsUpgrade { get
            {
                return Level > 0 ? true : false;
            } }
        public int Level = 0;
        protected SkillType _type;
        //
        protected Transform _skillParent;


        public virtual void MainAction()
        {
            Debug.Log("Use skill" + _type);
        }
        public SkillType getType()
        {
            return _type;
        }
    }
}
