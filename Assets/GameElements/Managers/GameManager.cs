using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using IJunior.TypedScenes;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using Platformer.UI.Popup;

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
        private PopupManager _popupManager;
        [SerializeField]
        private List<GameObject> DontDestroyOnLoadList;
        [HideInInspector]
        public bool IsNeedToLoad  = false;
        public LevelName Level = LevelName.First;

        public bool needToSave = false;

        public override void InstallBindings()
        {
            Container.BindInstance(_player).AsSingle();
            Container.BindInstance(_coinManager).AsSingle();
            Container.BindInstance(_gameManger).AsSingle();
            Container.BindInstance(_popupManager).AsSingle();

        }

        private void OnValidate()
        {
            if (_coinManager == null)
                Debug.LogError("_coinManager on GameManager is empty");
        }
        private void Awake()
        {
            _player ??= FindObjectOfType<Player>();
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
        private void Update()
        {
            if(needToSave)
            {
                SaveGame();
                needToSave = false;
            }
        }
        public void SaveGame()
        {
            SaveManager.SaveData(_player.GetSaveData(), Constans.PlayerSavePath);
            SaveManager.SaveData(_skillManager.GetSaveData(), Constans.SkillLevelSavePath);
        }
        public void StartNewGame()
        {
            var playerData = new PlayerSaveData();
            _player.SetSaveData(playerData);
            _skillManager.SetSaveData(new SkillsSaveData());
            LoadLevel(LevelName.First, true);
            
        }    
        public void LoadGame()
        {
            var playerData = SaveManager.LoadData<PlayerSaveData>(Constans.PlayerSavePath);
            _player.SetSaveData(playerData);
            _skillManager.SetSaveData(SaveManager.LoadData<SkillsSaveData>(Constans.SkillLevelSavePath));
            LoadLevel(playerData.MapLevel);

        }
        public void LoadLevel(LevelName level, bool isNeedToSetPlayerPosition = false)
        {
            if(isNeedToSetPlayerPosition)
                _player.transform.position = new Vector3(0f, 0f, 10);
            this.Level = level;
            switch (level)
            {
                case LevelName.First:
                    break;
                case LevelName.Second:
                    Level_2.Load();
                    break;

            }
            SaveGame();

        }
    }

}

//TODO LIST:
/* 
 * 7.  отталкивание 
 * 9. сделать через буфер на ногах
 * 10. матрица колизий
 * 11. переделать HealthBarController c листам вместо масивов
 * 12. хит реакт перса
 * 13. вынести функцию патруля отдельно
 * 17. менеджер монет причем статичный
 * 18. Доделать DeathZone
 * 19. фабрика монет
 * 20. dotween плагин 
 * 21. вынести моноинстайлер отдельно
 * 22. виньетка при получение урона
 * 23. худ через ивенты
 * 24. перенести эффект крови на плеера с шипов
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
  */

