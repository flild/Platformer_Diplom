using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using System.Collections;
using UnityEngine;


namespace Platformer.Units
{
    public class BoomPet : BaseUnit, IDamaged
    {
        private int _petNumber;
        private bool _isAttack;
        [SerializeField, Space]
        private GameObject _explosionPrefab;
        [SerializeField]
        private int _MaxPetTypes;
        [SerializeField]
        private float _timeToExplosion;
        [SerializeField]
        private float _ExplosionRadius;
        [SerializeField]
        private LayerMask _layerMaskToExplosion;


        override protected void Start()
        {
            base.Start();
            _petNumber = Random.Range(1, _MaxPetTypes+1);
            for (int i = 1; i < _MaxPetTypes+1; i++)
            {
                if(i == _petNumber)
                {
                    _animator.SetLayerWeight(_petNumber, 1f);
                }
                else
                {
                    _animator.SetLayerWeight(i, 0f);
                }
            }
        }
        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _ExplosionRadius);
        }
        protected override void Attack()
        {
            if (_isAttack)
                return;
            StartCoroutine(PreExplosionMove());
        }
        private IEnumerator PreExplosionMove()
        {
            var tempTime = _timeToExplosion;
            var direction = Vector2.zero;
            _isAttack = true;
            _IsPatroling = false;
            while (tempTime>0)
            {
                var tempDir = _player.transform.position - transform.position;
                tempDir = tempDir.normalized;
                direction.x = tempDir.x;
                
                Move(direction);
                tempTime -= Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            _animator.SetTrigger("Attack");
            var temp = _rb.velocity;
            temp.y = 1f;
            _rb.velocity = temp;
            yield return null;
        }
        public void StartExplosion_U()
        {
            Instantiate(_explosionPrefab,transform.position, Quaternion.identity);
            RaycastHit2D hit = Physics2D.CircleCast(transform.position,_ExplosionRadius,Vector2.zero,0f, _layerMaskToExplosion);
            if(hit.transform != null)
            {
                hit.transform.TryGetComponent<Player>(out Player player);
                if (player != null)
                {
                    player.TakeDamage(_Attackdamage);
                }
            }

            Destroy(gameObject);

        }

    }

}
