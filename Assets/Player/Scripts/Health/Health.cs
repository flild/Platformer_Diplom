using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    public class Health : MonoBehaviour
    {
        private Player _player;
        [SerializeField]
        private HealthBarController _healthBar;
        private void OnValidate()
        {
            if (_player == null)
                _player = GetComponent<Player>();
        }
        public void Heal(float value)
        {
            _player.Stats.Health += value;
            ClampHealth();
        }

        public void TakeDamage(float value)
        {
            _player.Stats.Health -= value;
            ClampHealth();
        }

        void ClampHealth()
        {
            _player.Stats.Health = Mathf.Clamp(_player.Stats.Health, 0, _player.Stats.MaxHealth);
            _healthBar.UpdateHeartsHUD();
        }
    }
}

