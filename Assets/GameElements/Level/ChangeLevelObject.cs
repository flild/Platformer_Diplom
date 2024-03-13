
using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using UnityEngine;
using Zenject;

namespace Platformer.Level
{
    [RequireComponent(typeof(Collider2D))]
    public class ChangeLevelObject : MonoBehaviour
    {
        [SerializeField]
        private LevelName LevelNameToChange;
        private GameManager _gameManager;
        private void Start()
        {
            _gameManager ??= FindObjectOfType<GameManager>();
        }
        private void OnValidate()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Player>(out Player player))
            {
                _gameManager.LoadLevel(LevelNameToChange, true);
            }
        }

    }

}
