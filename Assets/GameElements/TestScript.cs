
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField]
        private CoinManager coinManager;

        private void Start()
        {
            StartCoroutine(Delay());
        }
        private IEnumerator Delay()
        {
            yield return null;
            coinManager.SpawnCoins(3, transform.position);
        }
    }
}


