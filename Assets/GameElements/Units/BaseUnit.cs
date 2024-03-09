using Platformer.Units.PlayerSpace;
using System;
using System.Collections;
using UnityEngine;
using Zenject;


namespace Platformer.Units
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
    public abstract class BaseUnit : MonoBehaviour, IMonster
    {
        [SerializeField,Range(0f, 100f)]
        protected float _health;
        [SerializeField, Range(0f, 100f)]
        protected float _Attackdamage;
        [SerializeField]
        protected int _killBounty;
        [Inject, SerializeField]
        protected Player _player;
        [Inject, SerializeField]
        private CoinManager _coinManager;
        protected Animator _animator;
        protected Rigidbody2D _rb;
        protected SpriteRenderer _sprite;
        [SerializeField]
        protected float _moveSpeed;
        [SerializeField]
        protected Vector2 _patrolPoint1;
        [SerializeField]
        protected Vector2 _patrolPoint2;
        [SerializeField]
        protected float _PatrolDelay;
        protected Vector2 _currentPoint;
        private float _scanDelay = 1;
        [SerializeField]
        private float _minDetectionDistance;
        [SerializeField]
        protected bool _IsPatroling = true;

        public event EventHandler<IMonster> OnUnitDeathEvent;

        private void OnEnable()
        {
            _currentPoint = _patrolPoint1;
            StartCoroutine(PatrolWait());
            StartCoroutine(Scan());
        }

        private void Awake()
        {
            _animator ??= GetComponent<Animator>();
            _rb ??= GetComponent<Rigidbody2D>();
            _sprite ??= GetComponent<SpriteRenderer>();
        }
        protected virtual void Start()
        {
            _player ??= FindObjectOfType<Player>();
            _coinManager ??= FindObjectOfType<CoinManager>();
        }

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(_patrolPoint1, new Vector3(0.4f, 0.4f, 0f));
            Gizmos.DrawCube(_patrolPoint2, new Vector3(0.4f, 0.4f, 0f));
            Gizmos.color = new Color(1f,0f,0f,0.2f);
            Gizmos.DrawWireSphere(transform.position, _minDetectionDistance);
        }

        public virtual void TakeDamage(float value)
        {
            _health= _health - value;
            if(_health <= 0 )
            {
                Death();
            }
        }
        protected virtual void Attack()
        {

        }
        /// <summary>
        /// Ќужно отключать патруль
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="animated">по умолчанию true, поставить false, если движение происходит не своим ходом</param>
        protected void Move(Vector2 direction, bool animated = true)
        {
            if (direction.x == 0)
            {
                _animator.SetBool("moving", false);
                _rb.velocity = Vector2.zero;
                return;
            }
            if (direction.x > 0)
                _sprite.flipX = false;
            else if (direction.x < 0)
                _sprite.flipX = true;
            _rb.velocity = new Vector2(direction.x * _moveSpeed * Time.deltaTime, _rb.velocity.y);
            if(animated)
                _animator.SetBool("moving", true);
        }
        private IEnumerator Scan()
        {
            yield return null;
            while (true)
            {
                var distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
                if (distanceToPlayer < _minDetectionDistance)
                {
                    Attack();
                }
                yield return new WaitForSeconds(_scanDelay);
            }
        }
        private void Patroling()
        {
            StartCoroutine(MoveToPoint(new Vector2(_currentPoint.x, transform.position.y)));
        }
        private void SwitchCurrentPoint()
        {
            //задержка по€то€ть подышать
            if (_currentPoint == _patrolPoint1)
                _currentPoint = _patrolPoint2;
            else
                _currentPoint = _patrolPoint1;
            StartCoroutine(PatrolWait());
        }
        private IEnumerator PatrolWait()
        {
            Move(Vector2.zero);
            yield return new WaitForSeconds(_PatrolDelay);
            Patroling();
            yield return null;
        }
        private IEnumerator MoveToPoint(Vector2 point)
        {
            point.y = transform.position.y;
            var targetX = _currentPoint.x - transform.position.x;
            var targetPos = new Vector2(targetX, 0f).normalized;
            while (Vector2.Distance(transform.position, point) > 0.05)
            {
                yield return null;
                if(_IsPatroling)
                    Move(targetPos);
                else
                    Move(Vector2.zero);
            }
            SwitchCurrentPoint();
            yield return null;
        }
        public SpriteRenderer GetSprite()
        {
            return _sprite;
        }
        public void Death()
        {
            _coinManager.SpawnCoins(_killBounty,transform.position);
            OnUnitDeathEvent?.Invoke(this, this);
            Destroy(gameObject);
        }


    }
}


