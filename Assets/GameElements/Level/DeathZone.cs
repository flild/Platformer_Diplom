
using Platformer.Units.PlayerSpace;
using UnityEngine;

namespace Platformer.Level
{
    public class DeathZone : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.TakeDamage(999);
            }
        }
    }
}

