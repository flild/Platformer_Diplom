using UnityEngine;
using System.Collections;

namespace Platformer.Units
{
    public class YellowSphere : BaseUnit
    {
        [SerializeField]
        private Shoot _shoot;
        [SerializeField]
        private Animator _anim;
        [SerializeField]
        private float _attackDalay;
        private bool _isAttack = false;

        private void Start()
        {
            _IsPatroling = false;
            _shoot.Damage = _Attackdamage;
        }
        protected override void Attack()
        {
            if (_isAttack)
                return;
            _anim.SetTrigger("Attack");
        }
        public void Shoot_U()
        {
            _isAttack = true;
            _shoot.gameObject.SetActive(true);
            _shoot.transform.localPosition = Vector3.zero;
            //костыль
            var playerPos = _player.transform.position;
            playerPos.y += 1;
            _shoot.transform.right = playerPos - _shoot.transform.position;
            StartCoroutine(AttackDalay());
        }
        private IEnumerator AttackDalay()
        {
            yield return new WaitForSeconds(_attackDalay);
            _isAttack = false;
        }
    }
}

