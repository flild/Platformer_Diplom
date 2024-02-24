using Platformer.Extensions;
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
        [SerializeField]
        private GameManager _gameManger;
        [SerializeField]
        private SkillManager _skillManager;

        private string PlayerSavePath = "/Player.dat";
        private string SkillLevelSavePath = "/Skills.dat";


        public override void InstallBindings()
        {
            Container.BindInstance(_player).AsSingle();
            Container.BindInstance(_coinManager).AsSingle();
            Container.BindInstance(_gameManger).AsSingle();

        }

        private void OnValidate()
        {
            _player ??= FindObjectOfType<Player>();
            if (_coinManager == null)
                Debug.LogError("_coinManager on GameMager is empty");
            _gameManger ??= GetComponent<GameManager>();
        }

        public void SaveGame()
        {
            SaveManager.SaveData(_player.GetSaveData(), PlayerSavePath);
            SaveManager.SaveData(_skillManager.GetSaveData(), SkillLevelSavePath);
        }
        public void LoadGame()
        {
            _player.SetSaveData(SaveManager.LoadData<PlayerSaveData>(PlayerSavePath));
            _skillManager.SetSaveData(SaveManager.LoadData<SkillsSaveData>(SkillLevelSavePath));

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

