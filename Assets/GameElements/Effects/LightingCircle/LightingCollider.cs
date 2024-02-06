
using Platformer.Units;
using UnityEngine;

namespace Platformer.Effects
{
    public class LightingCollider : MonoBehaviour
    {
        private LightingAssistent _assistent;
        [SerializeField]
        private ParticleSystem _damageEffectPrefab;
        [SerializeField]
        private Lighting _baseSkill;
        private void Awake()
        {
            _assistent = new LightingAssistent(_damageEffectPrefab, _baseSkill.DamageEffectDuration);
        }
        private void OnValidate()
        {
            if (_baseSkill == null)
                _baseSkill.GetComponentInParent<Lighting>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IMonster>(out IMonster monster))
            {
                monster.TakeDamage(_baseSkill.Damage);
                _assistent.DamageEffectsController(monster);
            }
        }
    }
}


