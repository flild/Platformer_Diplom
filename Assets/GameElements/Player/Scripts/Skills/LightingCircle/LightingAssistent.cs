using Platformer.Extensions;
using Platformer.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Effects
{
    public class LightingAssistent
    {
        private Dictionary<IMonster, ParticleSystem> _targetsMap;
        private Dictionary<IMonster, bool> _targetLifeStatusMap;
        private ParticleSystem _damageEffectPrefab;
        private bool _IsEffected = false;
        private float _effectDuration;
        private float tempTime;
        public LightingAssistent(ParticleSystem damageEffectPrefab, float effectDuration)
        {
            _targetsMap = new Dictionary<IMonster, ParticleSystem>();
            _targetLifeStatusMap = new Dictionary<IMonster, bool>();
            this._damageEffectPrefab = damageEffectPrefab;
            this._effectDuration = effectDuration;
        }
        public void DamageEffectsController(IMonster monster)
        {
            if (_IsEffected)
            {
                tempTime = _effectDuration;
                return;
            }
            var particleSystem = GameObject.Instantiate(_damageEffectPrefab, monster.transform);
            _targetsMap.Add(monster, particleSystem);
            _targetLifeStatusMap.Add(monster, true);
            monster.OnUnitDeathEvent += OnMonsterDeath;
            CoroutineManager.StartRoutine(EffectRoutine(monster));
        }
        private IEnumerator EffectRoutine(IMonster target)
        {
            yield return new WaitForSeconds(_effectDuration);
            tempTime = _effectDuration;
            while(tempTime > 0)
            {
                tempTime-=Time.deltaTime;
                if(!_targetLifeStatusMap[target])
                {
                    tempTime=0;
                }
                yield return null;
            }
            EndEffect(target);
        }
        //todo оставить только сендер
        private void OnMonsterDeath(object sender, IMonster monster)
        {
            monster.OnUnitDeathEvent -= OnMonsterDeath;
            _targetLifeStatusMap[monster] = false;
        }
        private void EndEffect(IMonster target)
        {
            if (_targetLifeStatusMap.TryGetValue(target, out bool status) && status)
            {
                var effect = _targetsMap[target];
                GameObject.Destroy(effect);
            }
            _targetsMap.Remove(target);
            _targetLifeStatusMap.Remove(target);
        }
        
    }
}

