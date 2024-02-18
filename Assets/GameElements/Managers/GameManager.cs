using Platformer.Units.PlayerSpace;
using UnityEngine;
using Zenject;

namespace Platformer
{
    public class GameManager : MonoInstaller
    {
        [SerializeField]
        private Player _player;
        [SerializeField]
        private CoinManager _coinManager;

        public override void InstallBindings()
        {
            Container.BindInstance(_player).AsSingle();
            Container.BindInstance(_coinManager).AsSingle();

        }

        private void OnValidate()
        {
            _player ??= FindObjectOfType<Player>();
            if (_coinManager == null)
                Debug.LogError("_coinManager on GameMager is empty");
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
 * 17. �������� ����� ������ ���������
 * 18. �������� DeathZone
 * 19. ������� �����
 * 20. dotween ������ 
 * 21. ������� ������������� ��������
 * 22. �������� ��� ��������� �����
 * 23. ��� ����� ������
 * 24. ��������� ������ ����� �� ������ � �����
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
  */

