using UnityEngine;


namespace Platformer.Units
{
    [RequireComponent(typeof(Animator))]
    public class ViewComponent : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
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
        private int _IDSecondJump;
        private int _IDdeath;
        private int _IDAlive;


        private void Awake()
        {
            _animator ??= GetComponent<Animator>();
            _sprite ??= GetComponent<SpriteRenderer>();
            _IDIsRun = Animator.StringToHash("Runnig");
            _IDIsBlock = Animator.StringToHash("IsBlocking");
            _IDAttack = Animator.StringToHash("Attack");
            _IDYSpeed = Animator.StringToHash("YSpeed");
            _IDGrouded = Animator.StringToHash("Grounded");
            _IDJump = Animator.StringToHash("Jump");
            _IDSecondJump = Animator.StringToHash("SecondJump");
            _IDdeath = Animator.StringToHash("Death");
            _IDAlive = Animator.StringToHash("Alive");

        }
        private void Update()
        {
            _animator.SetFloat(_IDYSpeed, _YSpeed);
            _animator.SetBool(_IDGrouded, _isGrounded);
        }
        public void Run(Vector2 direction)
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
        public void Attack()
        {
            _animator.SetTrigger(_IDAttack);

        }
        public void Block(bool isBlock)
        {
            _animator.SetBool(_IDIsBlock, isBlock);
        }
        public void Jump()
        {
            _animator.SetTrigger(_IDJump);
        }
        public void SecondJump()
        {
            _animator.SetTrigger(_IDSecondJump);
        }
        public void EndAnyAnimation()
        {
            //todo
        }
        public void Death()
        {
            _animator.SetTrigger(_IDdeath);
        }
        public void Alive()
        {
            _animator.SetTrigger(_IDAlive);
        }
    }
}


