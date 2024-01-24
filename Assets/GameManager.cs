using Platformer.Units.PlayerSpace;
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
 * ����� �����, ��� ��, ���� �� ����� �� ����, ����� ����� �� ����� ������� ����, ����������
 * 
 * 7.  ������������ 
 * 9. ������� ����� ����� �� �����
 * 10. ������� �������
 * 11. ���������� HealthBarController c ������ ������ �������
 * 12. ��� ����� �����
 * 13. ������� ������� ������� ��������
 * 15. ���������, ��� ����� ����� � ����� �������� ������� � ��������� ������
 * 
 * 
 * 
 * 
 * 
 * 
  */

