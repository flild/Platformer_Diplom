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
 * Дамаг шипов, или хп, чето из этого не ворк, нужно чтобы от шипов получал урон, посмотреть
 * 
 * 7.  отталкивание 
 * 9. сделать через буфер на ногах
 * 10. матрица колизий
 * 11. переделать HealthBarController c листам вместо масивов
 * 12. хит реакт перса
 * 13. вынести функцию патруля отдельно
 * 15. пофиксить, что после пржка в стену персонаж остаётся в состоянии полета
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

