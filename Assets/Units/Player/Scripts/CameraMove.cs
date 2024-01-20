using UnityEngine;
using Zenject;

namespace Platformer.Units.PlayerSpace
{
    public class CameraMove : MonoBehaviour
    {
        [Inject]
        private Player _player;
        private Vector2 _tempPos;
        private void LateUpdate()
        {
            _tempPos = transform.position;
            _tempPos.x = _player.transform.position.x;
            transform.position = _tempPos;
        }
    }
}

