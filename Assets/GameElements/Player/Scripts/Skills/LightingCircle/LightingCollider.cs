using Platformer.Units;
using System;
using UnityEngine;

namespace Platformer.Effects
{
    public class LightingCollider : MonoBehaviour
    {
        public Action<IMonster> CollisionWithMonster; 
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IMonster>(out IMonster monster))
            {
                CollisionWithMonster?.Invoke(monster);
                
            }
        }
    }
}


