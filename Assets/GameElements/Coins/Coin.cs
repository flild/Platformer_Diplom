using Platformer.Units.PlayerSpace;
using DG.Tweening;
using UnityEngine;
using System.Collections;

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
        [SerializeField]
        private float PunchDuration;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.TryGetComponent<Player>(out Player player))
            {
                PlayerTakeCoin?.Invoke(this);
            }
            else
            {
                StartCoroutine(MakeCoinStatic());
            }
        }
        public void pushCoin()
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0f, 0f);
            _rb.AddForce(direction* _pushForce,ForceMode2D.Impulse);

            //transform.DOLocalMoveY(-4, PunchDuration);
            //transform.DOPunchPosition(direction*_pushForce, PunchDuration, vibrato: 3, elasticity: 0.3f);

        }
        private IEnumerator MakeCoinStatic()
        {
            yield return new WaitForSeconds(1f);
            _rb.bodyType = RigidbodyType2D.Static;
            yield return null;
        }

    }
}

