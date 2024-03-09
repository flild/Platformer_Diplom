using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    public class Sword : MonoBehaviour
    {
        private Collider2D _collider;
        private Player _player;

        private void Awake()
        {
            _collider ??= GetComponent<Collider2D>();
            _player ??= GetComponentInParent<Player>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if(collision.TryGetComponent(out IDamaged target))
            {
                target.TakeDamage(_player.Stats.Damage.Value);
                _collider.enabled = false;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}

