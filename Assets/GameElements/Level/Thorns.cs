using Platformer.Units.PlayerSpace;
using UnityEngine;

namespace Platformer.Level
{
    public class Thorns : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out Player _player))
            {
                _player.TakeDamage(0.5f);
            }
        }
    }
}

