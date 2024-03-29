using UnityEngine;
using System.Collections;

namespace Platformer.Units
{
    public class YellowSphere : BaseUnit, IDamaged
    {
        [SerializeField]
        private Shoot _shoot;
        [SerializeField]
        private Animator _anim;
        [SerializeField]
        private float _attackDalay;
        [SerializeField]
        private GameObject _trail;
        private bool _isAttack = false;

        override protected void Start()
        {
            base.Start();
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
            //�������
            var playerPos = _player.transform.position;
            playerPos.y += 1;
            _shoot.transform.right = playerPos - _shoot.transform.position;
            StartCoroutine(AttackDalay());
        }
        protected override void Move(Vector2 direction, bool animated = true)
        {
            _trail.transform.rotation = new Quaternion(0,direction.x >= 0 ? 0 : 180,0,0);
            base.Move(direction, animated);
        }
        private IEnumerator AttackDalay()
        {
            yield return new WaitForSeconds(_attackDalay);
            _isAttack = false;
        }
    }
}

