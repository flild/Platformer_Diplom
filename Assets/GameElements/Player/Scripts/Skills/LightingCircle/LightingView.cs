using Platformer.Effects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class LightingView: SkillViewBase
    {
        // нужно откуда то, включать
        [SerializeField]
        private Vector3 _minRadius;
        [SerializeField]
        private Vector3 _maxRadius;
        [SerializeField]
        private float _duration;
        [SerializeField]
        private List<Transform> _scaledTransforms;
        [SerializeField]
        private LightingCollider _collider;

        public ParticleSystem DamageEffectPrefab;

        public Action<IMonster> CollisionWithMonster;

        private void OnEnable()
        {
            StartCoroutine(ScalingScaleSize());

        }
        private void Start()
        {
            _collider.CollisionWithMonster += OnCollisionWithMonster;
        }

        private IEnumerator ScalingScaleSize()
        {
            float time = 0;
            float tempScaleCoef = 0;
            while (time < _duration)
            {
                tempScaleCoef = (time / _duration);
                foreach (Transform t in _scaledTransforms)
                {
                    t.localScale = Vector3.Lerp(_minRadius, _maxRadius, tempScaleCoef);
                }
                time += Time.deltaTime;
                yield return null;
            }
            yield return null;
            gameObject.SetActive(false);
        }
        private void OnCollisionWithMonster(IMonster monster)
        {
            CollisionWithMonster?.Invoke(monster);
        }
        private void OnDisable()
        {
            _collider.CollisionWithMonster -= OnCollisionWithMonster;
        }
    }
}
