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
        private ViewComponent _view;

        [SerializeField, Range(0f,10f), Space]
        private float _moveSpeed;
        [SerializeField, Range(0f, 100f)]
        private float _jumpForce;

        private bool _hasSecondJump;
        private bool _isGrounded;


        private void OnValidate()
        {
            if(_rb == null )
                _rb = GetComponent<Rigidbody2D>();
            if (_view == null)
                _view = GetComponent<ViewComponent>();
        }

        private void Update()
        {
            //todo timeScale
            _view._YSpeed = _rb.velocity.y;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //todo ������� ����� ������ �� �����
            //�������� ����, ������� �������
            _view._isGrounded = true;
            _hasSecondJump = true;
            _isGrounded = true;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _view._isGrounded = false;
            _isGrounded = false;
        }
        public void OnMove(Vector2 direction)
        {
            _rb.velocity = new Vector2(direction.x * _moveSpeed * Time.deltaTime * Constans.PlayerMoveScale, _rb.velocity.y);
            _view.Run(direction);
        }
        public void OnJump(CallbackContext context)
        {
            //ground false && second false  �������� ��� ������� 2 ���� OK
            //ground false && second true ������� ��� ������ ������ OK
            //ground true && second false  not posible
            //ground true && second true  ---> ������ ������
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
                //todo �������� ������ ������, �������� ��� _view.SecondJump
            }
            _rb.AddForce(Vector2.up*_jumpForce* Constans.PlayerJumpScale, ForceMode2D.Force);
            _view._isGrounded = false;

        }
        public void OnAttack(CallbackContext context)
        {
            _view.Attack();
        }
        public void OnBlock(bool isBlock)
        {
            _view.Block(isBlock);
        }
    }

}
