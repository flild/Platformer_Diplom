using Platformer.Extensions;
using Platformer.Units.PlayerSpace.Skill;


namespace Platformer.Units.PlayerSpace.Skill
{
    internal class IceComet: SkillBase
    {

        //private LightingView _lightingView;

        //public IceComet(LightingView view)
        //{
           // _lightingView = view;
            //Init();
        //}
        public IceComet()
        {
            Init();
        }
        public void Init()
        {
            Damage = 3;
            Level = 0;
            _type = SkillType.IceComet;
        }
        public override void MainAction()
        {
            base.MainAction();
        }
    }
}
