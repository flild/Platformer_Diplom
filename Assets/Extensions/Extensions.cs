using System;
using UnityEngine;
using System.Collections;
using Platformer.Units.PlayerSpace;

namespace Platformer.Extensions
{
    public static class Constans
    {
        public const float MoveScale = 100f;
        public const float PlayerJumpScale = 1000f;
        public const string PlayerSavePath = "/Player.dat";
        public const string SkillLevelSavePath = "/Skills.dat";
    }
    public enum SkillType
    {
        Lighting = 1,
        Heal = 2,
        IceComet = 3,
        Bubble = 4
    }
    [Serializable]
    public enum LevelName
    {
        First = 1,
        Second = 2
    }
    public enum SoundType
    {
        Jump,
        SwordAttack,
        TakeDamage
    }
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
    [Serializable]
    public class PlayerSaveData
    {
        public PlayerSaveData()
        {
            //скриптбл обжект
            
            PositionX = 0;
            PositionY = 0;
            FlipX = true;
            Coin = 400;
            Health = 4;
            Maxhealth = 3;
            Damage = 2;
            BlockDamage = 0.5f;
            Speed = 2f;
            MapLevel = LevelName.First;
        }
        public float PositionX;
        public float PositionY;
        public bool FlipX;
        public int Coin;

        public float Health;
        public float Maxhealth;
        public float Damage;
        public float BlockDamage;
        public float Speed;

        public LevelName MapLevel;
    }
    [Serializable]
    public class SkillsSaveData
    {
        public SkillsSaveData()
        {
            LightingLevel = 0;
            HealingLevel = 0;
            CometLevel = 0;
            BubbleLevel = 0;
        }
        public int LightingLevel;
        public int HealingLevel;
        public int CometLevel;
        public int BubbleLevel;
    }

    public class ReactiveProperty<T>
    {
        public event Action<T> OnChanged;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }

    public class MaxHealthReactiveProperty<T> 
    {
        public event Action<float> OnChanged;

        private float _value;
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
    public class HealthReactiveProperty<T>
    {
        public event Action<float> OnChanged;
        private Stats _stats;

        private float _value;
        public HealthReactiveProperty(Stats stats)
        {
            _stats = stats;
        }
        public float Value
        {
            get => _value;
            set
            {
                if (value > _stats.MaxHealth.Value)
                    value = _stats.MaxHealth.Value;
                else if (value <= 0 )
                    value = 0;
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}
    

