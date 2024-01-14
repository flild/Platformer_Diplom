using UnityEngine;
using Platformer.Extensions;
using static UnityEngine.InputSystem.InputAction;
using System;
using Platformer.Units.Player;
using static Platformer.Extensions.EditorExtensions;

namespace Platformer.Units
{
    [RequireComponent(typeof(Rigidbody2D),typeof(PlayerInputComponent),typeof(ViewComponent))]
    public class Movement2D : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        private Rigidbody2D _rb;
        [SerializeField, ReadOnly]
        private PlayerInputComponent _input;
        [SerializeField, ReadOnly]
        private ViewComponent _view;

        [SerializeField, Range(0f,10f), Space]
        private float _moveSpeed;
        [SerializeField, Range(0f, 100f)]
        private float _jumpForce;


        private void OnValidate()
        {
            if(_rb == null )
                _rb = GetComponent<Rigidbody2D>();
            if(_input == null)
                _input =GetComponent<PlayerInputComponent>();
            if (_view == null)
                _view = GetComponent<ViewComponent>();
        }

        private void Update()
        {
            //todo גûםוסעט ג מעהוכüםûי לועמה
            //todo timeScale
            OnMove(_input.GetMoveDirection());
            _view._YSpeed = _rb.velocity.y;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _view._isGrounded = true;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _view._isGrounded = false;
        }
        private void OnMove(Vector2 direction)
        {
            _rb.velocity = new Vector2(direction.x * _moveSpeed * Time.deltaTime * Constans.PlayerMoveScale, _rb.velocity.y);
            _view.RunView(direction);
        }
        public void OnJump(CallbackContext context)
        {
            _rb.AddForce(Vector2.up*_jumpForce* Constans.PlayerJumpScale, ForceMode2D.Force);
            _view._isGrounded = false;
            _view.JumpView();
        }
        public void OnAttack(CallbackContext context)
        {
            _view.AttackView();
        }
        public void OnBlock(bool isBlock)
        {
            _view.BlockView(isBlock);
        }
    }

}
