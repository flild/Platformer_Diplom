using Platformer.Extensions;


namespace Platformer.Units.PlayerSpace.Skill
{
    public class IceComet: SkillBase
    {

        private IceCometView _cometView;
        private float _flyDuration;
        private float _speed;

        public IceComet(IceCometView cometView)
        {
            _cometView = cometView;
            Init();
        }
        public void Init()
        {
            Damage = 2;
            Level = 0;
            _type = SkillType.IceComet;
            _flyDuration = 2;
            _speed = 6;
        }
        public override void MainAction()
        {
            base.MainAction();
            _cometView.gameObject.SetActive(true);
            _cometView.HitMonster += OnHittedMonster;
            _cometView.Shoot(_flyDuration, _speed);
        }
        private void OnHittedMonster(IMonster monster)
        {
            monster.TakeDamage(Damage * Level);
        }
    }
}
