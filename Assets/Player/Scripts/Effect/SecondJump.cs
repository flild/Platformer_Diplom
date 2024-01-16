using UnityEngine;
using static Platformer.Extensions.EditorExtensions;

namespace Platformer.Effects
{
    [RequireComponent(typeof(Animator))]
    public class SecondJump : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        private Animator _anim;
        //SecondJump

        private void OnValidate()
        {
            if( _anim == null )
                _anim = GetComponent<Animator>();
        }
        public void PlayEffect()
        {
            Debug.Log("play");
            _anim.SetTrigger("SecondJump");
        }
    }
}

