using Platformer.Player;
using UnityEngine;
using Platformer.Extensions;
using static UnityEngine.InputSystem.InputAction;
using System;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D),typeof(PlayerInputComponent))]
    public class Movement2D : MonoBehaviour
    {
        [SerializeField, Range(0f,10f)]
        private float _moveSpeed;
        [SerializeField, Range(0f,100f)]
        private float _jumpForce;


        [SerializeField, Space]
        private Rigidbody2D _rb;
        [SerializeField]
        private PlayerInputComponent _input;

        private Vector2 _moveVector = new Vector2(0f,0f);


        private void OnValidate()
        {
            if(_rb == null )
            {
                _rb = GetComponent<Rigidbody2D>();
            }
            if(_input == null)
                _input =GetComponent<PlayerInputComponent>();
        }

        private void Update()
        {
            _moveVector.x = _input.GetMoveDirection().x;
            //todo גûםוסעט ג מעהוכüםûי לועמה
            //todo timeScale
            _rb.velocity = new Vector2(_moveVector.x*_moveSpeed*Time.deltaTime* Constans.PlayerMoveScale, _rb.velocity.y);
        }

        public void OnJump(CallbackContext context)
        {
            _rb.AddForce(Vector2.up*_jumpForce* Constans.PlayerJumpScale, ForceMode2D.Force);
        }
    }

}
