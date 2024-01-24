using UnityEngine;
using System.Collections;
using Platformer.Units.PlayerSpace;

namespace Platformer.Units.Enemies
{

    public class Slime : BaseUnit, IDamaged
    {
        private bool _isAttack = false;
        [SerializeField]
        private float _sleepTime;
        [SerializeField]
        private float DamageImmunityEffectTime;
        private Vector2 _targetPos;
        private bool _IsSleep;
        [SerializeField]
        private ParticleSystem _blood;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<Player>(out Player _player))
            {
                if (_isAttack)
                {
                    _player.TakeDamage(_Attackdamage*2);
                }
                else if (_IsSleep)
                {
                    _player.TakeDamage(_Attackdamage * 0);
                }
                else
                {
                    _player.TakeDamage(_Attackdamage);
                }
            }

        }
        protected override void Attack()
        {
            if (_isAttack || _IsSleep)
                return;
            _isAttack = true; 
            var targetX = _player.transform.position.x - transform.position.x;
            _targetPos = new Vector2(targetX, 0f).normalized;
            StartCoroutine(MoveToTarget());
            _animator.SetTrigger("Attack");
        }
        public override void TakeDamage(float value)
        {
            if(_IsSleep)
                base.TakeDamage(value);
            StartCoroutine(DamageEffect());
        }
        public void EndAttackAnim()
        {
            _isAttack = false;
            StartCoroutine(Sleeping());
        }
        private IEnumerator Sleeping()
        {
            _animator.SetBool("Sleeping", true);
            _IsSleep = true;
            _IsPatroling = false;
            yield return new WaitForSeconds(_sleepTime);
            _animator.SetBool("Sleeping", false);
            _IsSleep = false;
            _IsPatroling = true;
            yield return null;
        } 
        private IEnumerator DamageEffect()
        {
            if(_IsSleep)
            {
                _blood.Play();
            }
            else
            {
                _sprite.color = new Color(216f, 255f, 0);
                yield return new WaitForSeconds(DamageImmunityEffectTime);
                _sprite.color = new Color(255f, 255f, 255f);
            }
            yield return null;
        }
        private IEnumerator MoveToTarget()
        {
            _IsPatroling = false;
            while (_isAttack)
            { 
                Move(_targetPos, false);
                yield return null;
            }
            if(!_IsSleep)
                _IsPatroling = true;
            yield return null;
        }

    }
}

