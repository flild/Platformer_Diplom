using Platformer.Effects;
using Platformer.Extensions;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class Lighting : SkillBase
    {
        private float _damageEffectDuration;
        public float DamageEffectDuration { get { return _damageEffectDuration; } }
        private LightingView _lightingView;

        private LightingAssistent _assistent;
        private ParticleSystem _damageEffectPrefab;
        public Lighting(LightingView view)
        {
            _lightingView = view;
            _damageEffectPrefab = _lightingView.DamageEffectPrefab;
            _assistent = new LightingAssistent(_damageEffectPrefab, DamageEffectDuration);
            Init();
        }
        public void Init()
        {
            Damage = 1;
            Level = 0;
            _type = SkillType.Lighting;
            _lightingView.CollisionWithMonster += OnCollisionWithMonster;
        }
        public void OnCollisionWithMonster(IMonster monster)
        {
            _assistent.DamageEffectsController(monster);
            monster.TakeDamage(Damage* Level);
        }
        public override void MainAction()
        {
            base.MainAction();
            _lightingView.gameObject.SetActive(true);
        }


    }
    
}

