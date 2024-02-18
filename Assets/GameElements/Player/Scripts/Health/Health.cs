using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    public class Health : MonoBehaviour
    {
        private Player _player;


        private void OnValidate()
        {
            if (_player == null)
                _player = GetComponent<Player>();
        }
        public void Heal(float value)
        {
            _player.Stats.Health.Value += value;
            ClampHealth();
        }

        public void TakeDamage(float value)
        {
            if(!_player.Stats.IsBabbled)
            {
                _player.Stats.Health.Value -= value;
            }
            ClampHealth();
        }

        void ClampHealth()
        {   
            if(_player.Stats.Health.Value <= 0)
            {
                _player.OnPlayerDeath();
            }
                _player.Stats.Health.Value = Mathf.Clamp(_player.Stats.Health.Value, 0, _player.Stats.MaxHealth.Value);
        }
    }
}

