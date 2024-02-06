using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Effects
{
    public class Lighting : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _minRadius;
        [SerializeField]
        private Vector3 _maxRadius;

        [SerializeField]
        private float _duration;
        [SerializeField]
        private float _damage;
        [SerializeField]
        private float _damageEffectDuration;
        [SerializeField]
        private ParticleSystem _damageEffectPrefab;
        [SerializeField]
        private List<Transform> _scaled;

        public float Damage { get { return _damage; } }
        public float DamageEffectDuration { get { return _damageEffectDuration; } }
        private void OnEnable()
        {
            StartCoroutine(ScalingScaleSize());
            
        }
        private IEnumerator ScalingScaleSize()
        {
            float time = 0;
            float temp = 0;
            while (time < _duration)
            {
                temp = (time / _duration);
                //todo question я что-то делаю не так
                foreach(Transform t in _scaled)
                 {
                     t.localScale = Vector3.Lerp(_minRadius, _maxRadius, temp);
                 }
                time +=  Time.deltaTime;
                yield return null;
            }
            yield return null;
            gameObject.SetActive(false);
        }

    }
    
}

