
using UnityEngine;

using IJunior.TypedScenes;


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

