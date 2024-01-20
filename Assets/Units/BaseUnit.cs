
using UnityEngine;

namespace Platformer.Units
{
    public abstract class BaseUnit : MonoBehaviour
    {
        [SerializeField,Range(0f, 100f)]
        protected float _health;
        [SerializeField, Range(0f, 100f)]
        protected float _Attackdamage;
        public void TakeDamage(float value)
        {
            _health-=value;
        }
        public virtual void Attack()
        {

        }
    }
}


