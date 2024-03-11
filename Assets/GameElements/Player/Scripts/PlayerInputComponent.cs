
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Movement2D))]
    public class PlayerInputComponent : MonoBehaviour
    {
        private PlayerController _controller;
        [SerializeField]
        private Movement2D _movement;
        //todo временное решение
        [SerializeField]
        private SkillManager _skillManager;

        private void Awake()
        {
            _movement ??= GetComponent<Movement2D>();
        }
        private void OnEnable()
        {
            _controller = new PlayerController();

            _controller.Enable();
            _controller.Player.Jump.performed += _movement.OnJump;
            _controller.Player.Attack.performed += _movement.OnAttack;
            _controller.Player.Block.started += OnStartBlock;
            _controller.Player.Block.canceled += OnEndBlock;

            _controller.Player.FirstSkill.performed += FirstSkill;
            _controller.Player.SecondSkill.performed += SecondSkill;
            _controller.Player.ThirdSkill.performed += ThirdSkill;
            _controller.Player.FourthSkill.performed += FourthSkill;


        }
        private void FixedUpdate()
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
            _controller.Player.FirstSkill.performed -= SecondSkill;
            _controller.Player.ThirdSkill.performed -= ThirdSkill;
            _controller.Player.FourthSkill.performed -= FourthSkill;
            _controller.Disable();
        }
        public Vector2 GetMoveDirection()
        {
            return _controller.Player.Move.ReadValue<Vector2>();
        }
        public void PlayerDeath()
        {
            _controller.Disable();
            _movement.OnDeath();
        }
        public void PlayerAlive()
        {
            _controller.Enable();
            _movement.OnAlive();
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
            UseSkill(Extensions.SkillType.Lighting);
        }
        private void SecondSkill(InputAction.CallbackContext context)
        {
            UseSkill(Extensions.SkillType.Heal);
        }
        private void ThirdSkill(InputAction.CallbackContext context)
        {
            UseSkill(Extensions.SkillType.IceComet);
        }
        private void FourthSkill(InputAction.CallbackContext context)
        {
            UseSkill(Extensions.SkillType.Bubble);
        }

        private void UseSkill(Extensions.SkillType type)
        {
            if (_skillManager.IsSkillBlocked(type))
            {
                return;
            }
            _skillManager.UseSkill(type);
        }
    }

}

