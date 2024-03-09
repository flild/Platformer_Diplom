
using UnityEngine;

namespace Platformer.Level
{
    public class ParalaxEffect : MonoBehaviour
    {
        private float _lenght,_startpos;
        [SerializeField]
        private Camera _cam;
        [SerializeField,Range(0,1)]
        private float _parallaxCoef;

        private void Awake()
        {
            _cam ??= Camera.main;
        }
        private void Start()
        {
            _startpos = transform.position.x;
            _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            float temp = (_cam.transform.position.x * (1 - _parallaxCoef));
            float dist = (_cam.transform.position.x * _parallaxCoef);
            transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

            if (temp > _startpos + _lenght)
                _startpos += _lenght;
            else if (temp < _startpos - _lenght)
                _startpos -= _lenght;
        }
    }
}


