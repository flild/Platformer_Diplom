using Platformer.Units.Player;
using UnityEngine;
using Zenject;

namespace Platformer
{
    public class GameManager : MonoInstaller
    {
        [SerializeField]
        private Player _player;

        public override void InstallBindings()
        {
            Container.BindInstance(_player).AsSingle();

        }

        private void OnValidate()
        {
            if (_player == null)
                _player = FindObjectOfType<Player>();
        }
    }
}

//TODO LIST:
/*
 * 3. ������� ������� ��������� �� ������ � ��.
 * 5. ��������� �����
 * 7. ����, ����� �� �����, ������������
 * 8. �� ������, ������, 
 * 
 * 
 * 
 * 
 * 
  */

