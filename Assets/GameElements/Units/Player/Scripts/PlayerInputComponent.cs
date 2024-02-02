using Platformer.Effects;
using UnityEngine;
using UnityEngine.InputSystem;
using static Platformer.Extensions.EditorExtensions;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Movement2D))]
    public class PlayerInputComponent : MonoBehaviour
    {
        private PlayerController _controller;
        [SerializeField, ReadOnly]
        private Movement2D _movement;
        //todo временное решение
        [SerializeField]
        private Lighting _pref;

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
            _controller.Player.Attack.performed += _movement.OnAttack;
            _controller.Player.Block.started += OnStartBlock;
            _controller.Player.Block.canceled += OnEndBlock;

            //todo временно
            _controller.Player.FirstSkill.performed += FirstSkill;


        }
        private void Update()
        {
            _movement.OnMove(GetMoveDirection());
        }
        private void OnDisable()
        {
            _controller.Player.Jump.performed -= _movement.OnJump;
            _controller.Player.Attack.performed -= _movement.OnAttack;
            _controller.Player.Block.started -= OnStartBlock;
            _controller.Player.Block.performed -= OnEndBlock;
            _controller.Player.FirstSkill.performed -= FirstSkill;
            _controller.Disable();
        }
        public Vector2 GetMoveDirection()
        {
            return _controller.Player.Move.ReadValue<Vector2>();
        }
        private void OnStartBlock(InputAction.CallbackContext context)
        {
            _movement.OnBlock(true);
        }
        private void OnEndBlock(InputAction.CallbackContext context)
        {
            _movement.OnBlock(false);
        }

        private void FirstSkill(InputAction.CallbackContext context)
        {
            _pref.gameObject.SetActive(true);
        }
    }

}

