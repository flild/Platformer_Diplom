using UnityEngine;
using TMPro;
using System.Collections;
using System;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class CooldownView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text timer;
        private float _duration;
        [SerializeField]
        private float _delayStep = 0.3f;
        public event Action EndCooldown;

        private void Start()
        {
            timer ??= GetComponentInChildren<TMP_Text>();
        }

        public void StartCooldown(float duration)
        {
            _duration = duration;
            StartCoroutine(Cooldown());
        }
        private IEnumerator Cooldown()
        {
            while(_duration>0)
            {
                timer.text = Mathf.Round(_duration).ToString();
                _duration -= _delayStep;
                yield return new WaitForSeconds(_delayStep);
            }
            EndCooldown?.Invoke();
            gameObject.SetActive(false);
        }
    }
}

