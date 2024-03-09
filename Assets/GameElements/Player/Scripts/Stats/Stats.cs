using Platformer.Extensions;
using System;
using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    public class Stats : MonoBehaviour
    {
        public MaxHealthReactiveProperty<float> MaxHealth = new();
        //Health
        public HealthReactiveProperty<float> Health;

        //Jump
        [Space, Header("Jump"), Range(0, 15)]
        public float JumpForce;

        //speed
        [Header("Speed"), Range(0, 15)]
        public ReactiveProperty<float> Speed = new();
        public float MaxSpeed;
        public float MinSpeed;

        public ReactiveProperty<float> Damage = new();
        public ReactiveProperty<float> BlockDamage = new();
        //todo Luck
        public bool IsBabbled = false;
        private void Awake()
        {
            Init();
        }
        public void Init()
        {
            Health = new(this);
            MaxHealth.Value = 5;
            Health.Value = 4;
            Damage.Value = 3;
            BlockDamage.Value = 0.5f;
            Speed.Value = 2;
            
        }

        private void Start()
        {
            MaxHealth.Value = Health.Value;
        }
    }


}

