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
 * Дамаг шипов, или хп, чето из этого не ворк, нужно чтобы от шипов получал урон, посмотреть
 * 
 * 7.  отталкивание 
 * 9. сделать через буфер на ногах
 * 10. матрица колизий
 * 11. переделать HealthBarController c листам вместо масивов
 * 12. хит реакт перса
 * 13. вынести функцию патруля отдельно
 * 15. пофиксить, что после пржка в стену персонаж остаётся в состоянии полета
 * 
 * 
 * 
 * 
 * 
 * 
  */

