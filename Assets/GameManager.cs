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
 * 3. Сделать уровень нормально со слоями и тд.
 * 5. Коллайдер удара
 * 7. шипы, кровь от шипов, отталкивание
 * 8. хп игрока, смерть, 
 * 
 * 
 * 
 * 
 * 
  */

