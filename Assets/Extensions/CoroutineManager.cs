
using System.Collections;
using UnityEngine;

namespace Platformer.Extensions
{
    public sealed class CoroutineManager : MonoBehaviour
    {
        private static CoroutineManager instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("[COROUTINE MANAGER");
                    _instance = go.AddComponent<CoroutineManager>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }
        private static CoroutineManager _instance;
        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return instance.StartCoroutine(enumerator);
        }
        public static void StopRoutine(Coroutine routine)
        {
            instance.StopCoroutine(routine);
        }
    }
}

