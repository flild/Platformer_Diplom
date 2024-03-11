using Platformer.Extensions;


namespace Platformer.Units.PlayerSpace.Skill
{
    public class IceComet: SkillBase
    {
        private float _flyDuration;
        private float _speed;

        public IceComet(IceCometView cometView)
        {
            _skillView = cometView;
            Init();
        }
        public void Init()
        {
            Damage = 2;
            Level = 0;
            _type = SkillType.IceComet;
            _flyDuration = 2;
            _speed = 6;
            _cooldownDuration = 5;
        }
        public override void MainAction()
        {
            base.MainAction();
            _skillView.gameObject.SetActive(true);
            (_skillView as IceCometView).HitMonster += OnHittedMonster;
            (_skillView as IceCometView).Shoot(_flyDuration, _speed);
        }
        private void OnHittedMonster(IMonster monster)
        {
            monster.TakeDamage(Damage * Level);
        }
    }
}
