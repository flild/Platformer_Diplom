using UnityEngine;

namespace Platformer.Player
{
    [RequireComponent(typeof(Movement2D))]
    public class PlayerInputComponent : MonoBehaviour
    {
        private PlayerController _controller;
        private Movement2D _movement;

        private void OnValidate()
        {
            if(_movement == null)
            {
                _movement = GetComponent<Movement2D>();
            }
        }
        private void OnEnable()
        {
            _controller = new PlayerController();

            _controller.Enable();
            _controller.Player.Jump.performed += _movement.OnJump;


        }
        private void OnDisable()
        {
            _controller.Player.Jump.performed -= _movement.OnJump;
            _controller.Disable();
        }
        public Vector2 GetMoveDirection()
        {
            return _controller.Player.Move.ReadValue<Vector2>();
        }

    }

}

