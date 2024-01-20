
using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Stats),typeof(Health),typeof(ViewComponent))]
    public class Player : MonoBehaviour
    {
        private Stats _stats;
        private Health _health;
        private ViewComponent _view;
        // вынести хелс в отдельный файл, сделать всю логику там, сюда ссылку дать
        public Stats Stats { get { return _stats; } }
        private void OnValidate()
        {
            if(_stats == null)
                _stats = GetComponent<Stats>();
            if (_health == null)
                _health = GetComponent<Health>();
            if (_view == null)
                _view = GetComponent<ViewComponent>();
        }
        public void OnPlayerDeath()
        {
            _view.Death();
        }
        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);
        }
        
    }
}


