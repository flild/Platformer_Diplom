
using UnityEngine;

namespace Platformer
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource PlayerSwordAttack;

        public void PlaySwordAttackAudio()
        {
            PlayerSwordAttack.Play();
        }

    }
}

