using Platformer.Effects;
using Platformer.Extensions;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class Lighting : SkillBase
    {
        private float _damageEffectDuration;
        public float DamageEffectDuration { get { return _damageEffectDuration; } }

        private LightingAssistent _assistent;
        private ParticleSystem _damageEffectPrefab;
        public Lighting(LightingView view)
        {
            _skillView = view;
            _damageEffectPrefab = (_skillView as LightingView).DamageEffectPrefab;
            _assistent = new LightingAssistent(_damageEffectPrefab, DamageEffectDuration);
            Init();
        }
        public void Init()
        {
            Damage = 1;
            Level = 0;
            _type = SkillType.Lighting;
            (_skillView as LightingView).CollisionWithMonster += OnCollisionWithMonster;
            _cooldownDuration = 8;
        }
        public void OnCollisionWithMonster(IMonster monster)
        {
            _assistent.DamageEffectsController(monster);
            monster.TakeDamage(Damage* Level);
        }
        public override void MainAction()
        {
            base.MainAction();
            (_skillView as LightingView).gameObject.SetActive(true);
        }


    }
    
}

