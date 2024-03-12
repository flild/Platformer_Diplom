using System;
using System.Collections;
using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
    public class IceCometView: SkillViewBase
    {
        [SerializeField]
        private Player _player;
        private SpriteRenderer _sprite;
        private float _duration;
        private float _speed;
        private Rigidbody2D _rb;

        public Action<IMonster> HitMonster;

        public void Shoot(float duration, float speed)
        {
            this._duration = duration;
            this._speed = speed;
            _rb = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
            transform.parent = null;
            StartCoroutine(ShootingRoutine());
        }
        private IEnumerator ShootingRoutine()
        {
            var tempPos = _player.transform.position;
            tempPos.y += 1;
            transform.position = tempPos;
            var directionX = _player.GetFlipX() ? -1 : 1;
            var time = 0f;
            _sprite.flipX = _player.GetFlipX();
            while (time < _duration)
            {
                _rb.velocity = Vector2.right * directionX * _speed;
                time += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            Disable();
            yield return null;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.TryGetComponent<IMonster>(out IMonster monster))
            {
                HitMonster?.Invoke(monster);
            }
            Disable();
        }
        private void Disable()
        {
            transform.parent = _player.transform;
            gameObject.SetActive(false);
        }
    }
}
