using Platformer.Units.PlayerSpace;
using UnityEngine;

namespace Platformer.Level
{
    public class Thorns : MonoBehaviour
    {
        private ParticleSystem _blood;
        private void OnValidate()
        {
            if(_blood == null)
            {
                _blood = GetComponentInChildren<ParticleSystem>();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out Player _player))
            {
                _blood.transform.position = _player.transform.position;
                _blood.Play();
                _player.TakeDamage(0.5f);
            }
        }
    }
}

