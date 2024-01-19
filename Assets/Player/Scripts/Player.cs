
using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Stats),typeof(Health),typeof(ViewComponent))]
    public class Player : MonoBehaviour
    {
        private Stats _stats;
        private Health _health;
        private ViewComponent _view;
        // ������� ���� � ��������� ����, ������� ��� ������ ���, ���� ������ ����
        public Stats Stats { get { return _stats; } }
        public Health Health { get { return _health; } }
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
        
    }
}


