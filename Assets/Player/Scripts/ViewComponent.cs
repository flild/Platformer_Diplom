using UnityEngine;
using static Platformer.Extensions.EditorExtensions;

namespace Platformer.Units
{
    [RequireComponent(typeof(Animator))]
    public class ViewComponent : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        private Animator _animator;
        [SerializeField, ReadOnly]
        private SpriteRenderer _sprite;

        [HideInInspector]
        public bool _isGrounded;
        [HideInInspector]
        public float _YSpeed;
        //Anim parametrs IDs
        private int _IDIsRun;
        private int _IDIsBlock;
        private int _IDAttack;
        private int _IDYSpeed;
        private int _IDJump;
        private int _IDGrouded;

        private void OnValidate()
        {
           if( _animator == null )
            {
                _animator = GetComponent<Animator>();
            }
            if (_sprite == null)
                _sprite = GetComponent<SpriteRenderer>();
        }
        private void Awake()
        {
            _IDIsRun = Animator.StringToHash("Runnig");
            _IDIsBlock = Animator.StringToHash("IsBlocking");
            _IDAttack = Animator.StringToHash("Attack");
            _IDYSpeed = Animator.StringToHash("YSpeed");
            _IDGrouded = Animator.StringToHash("Grounded");
            _IDJump = Animator.StringToHash("Jump");
        }
        private void Update()
        {
            _animator.SetFloat(_IDYSpeed, _YSpeed);
            _animator.SetBool(_IDGrouded, _isGrounded);
        }
        public void RunView(Vector2 direction)
        {
            if (direction.x == 0)
                _animator.SetBool(_IDIsRun, false);
            else if(direction.x >0)
            {
                _animator.SetBool(_IDIsRun, true);
                _sprite.flipX = false;

            }
            else //direction.x<0
            {
                _animator.SetBool(_IDIsRun, true);
                _sprite.flipX = true;
            }
        }
        public void AttackView()
        {
            _animator.SetTrigger(_IDAttack);

        }
        public void BlockView(bool isBlock)
        {
            _animator.SetBool(_IDIsBlock, isBlock);
        }
        public void JumpView()
        {
            _animator.SetTrigger(_IDJump);
        }
        public void EndAnyAnimation()
        {
            //todo
        }
    }
}


