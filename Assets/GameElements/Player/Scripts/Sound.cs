using AYellowpaper.SerializedCollections;
using Platformer.Extensions;
using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(AudioSource))]
    public class Sound : MonoBehaviour
    {
        public SerializedDictionary<SoundType, AudioClip> _soundsMap;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }
        /// <summary>
        /// Play selected sound from sound map
        /// </summary>
        /// <param name="type">sound type from enum</param>
        /// <param name="pithc1">min value for random sound pitch</param>
        /// <param name="pitch2">Max value for random sound pitch</param>
        public void PlaySound(SoundType type, float pitch1 = 0.85f, float pitch2 = 1.2f)
        {
            _audioSource.clip = _soundsMap[type];
            _audioSource.pitch = Random.Range(pitch1, pitch2);
            _audioSource.Play();
        }
    }
}

