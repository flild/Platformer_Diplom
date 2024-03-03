using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using IJunior.TypedScenes;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

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
        [SerializeField]
        private List<GameObject> DontDestroyOnLoadList;
        [HideInInspector]
        public bool IsNeedToLoad  = false;

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
                Debug.LogError("_coinManager on GameManager is empty");
            _gameManger ??= GetComponent<GameManager>();
        }
        private void Start()
        {
            foreach(var go in DontDestroyOnLoadList)
            {
                DontDestroyOnLoad(go);
            }
            if(IsNeedToLoad)
            {
                LoadGame();
            }
            
        }
        public void SaveGame()
        {
            SaveManager.SaveData(_player.GetSaveData(), Constans.PlayerSavePath);
            SaveManager.SaveData(_skillManager.GetSaveData(), Constans.SkillLevelSavePath);
        }
        public void LoadGame()
        {
            var playerData = SaveManager.LoadData<PlayerSaveData>(Constans.PlayerSavePath);
            _player.SetSaveData(playerData);
            _skillManager.SetSaveData(SaveManager.LoadData<SkillsSaveData>(Constans.SkillLevelSavePath));
            var enumList = (LevelName[])System.Enum.GetValues(typeof(LevelName));
            LoadLevel(enumList[playerData.MapLevel]);

        }
        public void LoadLevel(LevelName level)
        {
            _player.transform.position = new Vector3(0f, 0f, 10);
            switch (level)
            {
                case LevelName.First:
                    
                    break;
                case LevelName.Second:
                    Level_2.Load();
                    break;

            }

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

