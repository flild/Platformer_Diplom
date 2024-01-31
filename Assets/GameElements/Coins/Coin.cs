using Platformer.Units.PlayerSpace;
using UnityEngine;

namespace Platformer.Level
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public class Coin : MonoBehaviour
    {
        public delegate void EventHandler(Coin coin);
        public event EventHandler PlayerTakeCoin;
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private float _pushForce;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.TryGetComponent<Player>(out Player player))
            {
                
                PlayerTakeCoin?.Invoke(this);
            }
        }
        public void pushCoin()
        {
            Vector2 direction = new Vector2(Random.Range(-1, 1), 1);
            _rb.AddForce(direction* _pushForce,ForceMode2D.Impulse);
        }

    }
}

