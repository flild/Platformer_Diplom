
using Platformer.Extensions;
using Platformer.UI.Popup;
using UnityEngine;
using Zenject;

namespace Platformer.Units.PlayerSpace
{
    [RequireComponent(typeof(Stats),typeof(Health),typeof(ViewComponent))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Stats _stats;
        private Health _health;
        [SerializeField]
        private Collider2D _swordCollider;
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private PlayerInputComponent _input;
        [SerializeField]
        private ParticleSystem _blood;

        [Inject]
        private CoinManager _coinManager;
        [Inject]
        private GameManager _gameManager;
        [Inject]
        private PopupManager _popupManager;
        // вынести хелс в отдельный файл, сделать всю логику там, сюда ссылку дать
        public Stats Stats { get { return _stats; } }

        private void Awake()
        {
            _stats ??= GetComponent<Stats>();
            _health ??= GetComponent<Health>();
        }
        public void PlayerDeath()
        {
            _input.PlayerDeath();
            _popupManager.ActivatePopup(PopupStorage.Instance.DeathPopup);
        }
        public void PlayerAlive()
        {
            _input.PlayerAlive();
        }
        public bool GetFlipX()
        {
            return _sprite.flipX;
        }
        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);
            _blood.Play();
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
            data.MapLevel = _gameManager.Level;
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
            _gameManager.Level = data.MapLevel;
        }
    }
}


