using Platformer.Level;
using UnityEngine;
using UnityEngine.Pool;

namespace Platformer
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField]
        private Coin _prefabCoin;
        private ObjectPool<Coin> _coinPool;
        private void Start()
        {
            _coinPool = new ObjectPool<Coin>(
                createFunc: () => Instantiate(_prefabCoin, transform),
                actionOnGet: (Coin) => Coin.gameObject.SetActive(true),
                actionOnRelease: (Coin) => Coin.gameObject.SetActive(false),
                actionOnDestroy: (Coin) => Destroy(Coin.gameObject),
                collectionCheck: false,
                defaultCapacity: 5,
                maxSize: 10);
        }
        public void SpawnCoins(int cout, Vector3 position)
        {
            Coin temp;
            for(int i = 0; i < cout; i++)
            {
                temp = _coinPool.Get();
                temp.transform.position = position;
                temp.pushCoin();
                temp.PlayerTakeCoin += ReturnCoin;
            }
        }
        public void ReturnCoin(Coin coin)
        {
            coin.PlayerTakeCoin -= ReturnCoin;
            _coinPool.Release(coin);
        }
        
    }
}

