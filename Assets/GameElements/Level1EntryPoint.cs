using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using UnityEngine;
using Zenject;
using IJunior.TypedScenes;
using System.Collections;

namespace Platformer
{
    public class Level1EntryPoint : MonoBehaviour, ISceneLoadHandler<bool>
    {
        [SerializeField]
        private GameManager _gameManager;
        public void OnSceneLoaded(bool IsNeedToLoad)
        {
            _gameManager.IsNeedToLoad = IsNeedToLoad;
        }

    }
}

