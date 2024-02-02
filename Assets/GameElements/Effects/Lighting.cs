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
        private List<Transform> _scaled;
        
        private void OnEnable()
        {
            StartCoroutine(ScalinScaleSize());
        }
        private IEnumerator ScalinScaleSize()
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

