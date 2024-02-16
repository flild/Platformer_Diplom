using System;
using UnityEngine;
using System.Collections;
using Platformer.Units.PlayerSpace;

namespace Platformer.Extensions
{
    public static class Constans
    {
        public const float PlayerMoveScale = 100f;
        public const float PlayerJumpScale = 1000f;
    }
    public enum SkillType
    {
        Lighting = 1,
        Heal = 2,
        IceComet = 3,
        Bubble = 4
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
                else
                    _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}
    

