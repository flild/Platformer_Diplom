using UnityEngine;
using Platformer.Extensions;
using static UnityEngine.InputSystem.InputAction;
using System;
using Platformer.Units.PlayerSpace;
using Zenject;

namespace Platformer.Units
{
    [RequireComponent(typeof(Rigidbody2D),typeof(PlayerInputComponent),typeof(ViewComponent))]
    public class Movement2D : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        private ViewComponent _view;
        [SerializeField]
        private Sound _sound;
        [SerializeField]
        private AirBoofer _airBoofer;
        [Inject]
        private Player _player;

        private bool _hasSecondJump;
        private bool _isGrounded;

        private void Awake()
        {

            _rb ??= GetComponent<Rigidbody2D>();
            _view ??= GetComponent<ViewComponent>();
            _sound ??= GetComponent<Sound>();
            _airBoofer ??= GetComponentInChildren<AirBoofer>();
        }
        private void Start()
        {
            _airBoofer.TouchGround += OnGroundCollision;
            _airBoofer.LeaveGround += OnGroundOut;
        }
        private void Update()
        {
            //todo timeScale
            _view._YSpeed = _rb.velocity.y;
        }
        private void OnDisable()
        {
            _airBoofer.TouchGround -= OnGroundCollision;
            _airBoofer.LeaveGround -= OnGroundOut;
        }

        public void OnGroundCollision()
        {
            _view._isGrounded = true;
            _hasSecondJump = true;
            _isGrounded = true;
        }
        public void OnGroundOut()
        {
            _view._isGrounded = false;
            _isGrounded = false;
        }
        public void OnMove(Vector2 direction)
        {
            _rb.velocity = new Vector2(direction.x * _player.Stats.Speed.Value * Time.deltaTime * Constans.MoveScale, _rb.velocity.y);
             var temp = _rb.velocity;
            temp.x = Math.Clamp(_rb.velocity.x, -_player.Stats.MaxSpeed, _player.Stats.MaxSpeed);
            _rb.velocity = temp;
            _view.Run(direction);
        }
        public void OnJump(CallbackContext context)
        {
            //ground false && second false  персонаж уже прыгнул 2 раза OK
            //ground false && second true падение или второй прыжок OK
            //ground true && second false  not posible
            //ground true && second true  ---> первый прыжок
            if (_view.InAnimation)
                return;
            if( _isGrounded)
            {
                _view.Jump();
            } 
            if (!_isGrounded && !_hasSecondJump)
            {
                return;
            }
            else if (!_isGrounded && _hasSecondJump)
            {
                _hasSecondJump = false;
                var temp = _rb.velocity;
                temp.y = 0;
                _rb.velocity = temp;
                _view.SecondJump();
            }
            _sound.PlaySound(SoundType.Jump);
            _rb.AddForce(Vector2.up*_player.Stats.JumpForce* Constans.PlayerJumpScale, ForceMode2D.Force);
            _view._isGrounded = false;

        }

        public void OnAttack(CallbackContext context)
        {
            _view.Attack();
            _sound.PlaySound(SoundType.SwordAttack);
            _player.OnAttack();
        }
        public void OnDeath()
        {
            _view.Death();

        }
        public void OnAlive()
        {
            _view.Alive();
        }
        public void OnBlock(bool isBlock)
        {
            _view.Block(isBlock);
        }
    }

}
