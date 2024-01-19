
using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Stats),typeof(Health))]
    public class Player : MonoBehaviour
    {
        private Stats _stats;
        private Health _health;
        // вынести хелс в отдельный файл, сделать всю логику там, сюда ссылку дать
        public Stats Stats { get { return _stats; } }
        public Health Health { get { return _health; } }
        private void OnValidate()
        {
            if(_stats == null)
                _stats = GetComponent<Stats>();
            if (_health == null)
                _health = GetComponent<Health>();
        }
        
    }
}


