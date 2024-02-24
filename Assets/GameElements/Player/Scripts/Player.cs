
using Platformer.Extensions;
using UnityEngine;
using Zenject;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Stats),typeof(Health),typeof(ViewComponent))]
    public class Player : MonoBehaviour
    {
        private Stats _stats;
        private Health _health;
        private ViewComponent _view;
        [SerializeField]
        private Collider2D _swordCollider;
        [SerializeField]
        private SpriteRenderer _sprite;
        [Inject]
        private CoinManager _coinManager;
        // вынести хелс в отдельный файл, сделать всю логику там, сюда ссылку дать
        public Stats Stats { get { return _stats; } }
        private void OnValidate()
        {
            if(_stats == null)
                _stats = GetComponent<Stats>();
            if (_health == null)
                _health = GetComponent<Health>();
            if (_view == null)
                _view = GetComponent<ViewComponent>();
        }
        public void OnPlayerDeath()
        {
            _view.Death();
        }
        public bool GetFlipX()
        {
            return _sprite.flipX;
        }
        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);
        }
        public void OnAttack()
        {
            _swordCollider.enabled = true;
        }
        public void OnAttackEnd()
        {
            _swordCollider.enabled = false;
        }
        public PlayerSaveData GetSaveData()
        {
            var data = new PlayerSaveData();
            data.Coin = _coinManager.GetPlayerCoinCount();
            data.Maxhealth = _stats.MaxHealth.Value;
            data.Health = _stats.Health.Value;
            data.Damage = _stats.Damage.Value;
            data.BlockDamage = _stats.BlockDamage.Value;
            data.Speed = _stats.Speed.Value;
            data.FlipX = _sprite.flipX;
            data.PositionX = transform.position.x;
            data.PositionY = transform.position.y;

            return data;
        }
        public void SetSaveData(PlayerSaveData data)
        {
            _coinManager.ChangeCoinValue(data.Coin);
            _stats.MaxHealth.Value = data.Maxhealth;
            _stats.Health.Value = data.Health;
            _stats.BlockDamage.Value = data.BlockDamage;
            _stats.Speed.Value = data.Speed;
            _sprite.flipX = data.FlipX;
            var tempPos = new Vector3(data.PositionX,data.PositionY, 10f);
            transform.position = tempPos;
        }
    }
}


