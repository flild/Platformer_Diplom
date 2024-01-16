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
 * 1. ��������� ����� � ���� ���������, ����� ������ ���� ������ ����� -->���
 * 2. ��������� �������� ���� ������ (��������� � � �������� AC
 * 3. ������� ������� ��������� �� ������ � ��.
 * 4. ��������� ���������� ���� ���(����� ���� �� ����������� �� ������ �����)
 * 5. ��������� �����
 * 
 * 
 * 
 * 
 * 
 * 
 * 
  */

