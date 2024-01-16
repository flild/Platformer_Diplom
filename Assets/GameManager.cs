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
 * 1. Развязать инпут и мову компонент, связь должна быть только инпут -->мув
 * 2. Исправить анимацию дабл джампа (перенести её в основной AC
 * 3. Сделать уровень нормально со слоями и тд.
 * 4. Пофиксить коллайдеры тайл мап(чтобы перс не подскакивал на ровном месте)
 * 5. Коллайдер удара
 * 
 * 
 * 
 * 
 * 
 * 
 * 
  */

