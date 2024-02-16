using Platformer.Level;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

namespace Platformer
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField]
        private Coin _prefabCoin;
        [SerializeField]
        private TMP_Text _coinsHUD;
        private ObjectPool<Coin> _coinPool;

        private int _coinCount = 500;
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
            UpdateCoinHud();
        }
        public int GetPlayerCoinCount()
        {
            return _coinCount;
        }
        public void AddCoinToPlayer(int value)
        {
            _coinCount += value;
            UpdateCoinHud();
        }
        public void ChangeCoinValue(int value)
        {
            _coinCount = value;
            UpdateCoinHud();
        }
        public void SpendCoin(int value)
        {
            _coinCount -= value;
            UpdateCoinHud();
        }
        private void UpdateCoinHud()
        {
            _coinsHUD.text = _coinCount.ToString();
        }
        private void PlayerPickupCoin(Coin coin)
        {
            coin.PlayerTakeCoin -= PlayerPickupCoin;
            AddCoinToPlayer(1);
            ReturnCoin(coin);

        }

        public void SpawnCoins(int cout, Vector3 position)
        {
            Coin temp;
            for(int i = 0; i < cout; i++)
            {
                temp = _coinPool.Get();
                temp.transform.position = position;
                temp.pushCoin();
                temp.PlayerTakeCoin += PlayerPickupCoin;
            }
        }

        public void ReturnCoin(Coin coin)
        {
            _coinPool.Release(coin);
        }
        
    }
}

