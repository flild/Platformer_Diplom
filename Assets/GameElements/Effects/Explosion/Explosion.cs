using UnityEngine;

namespace Platformer.Effects
{
    public class Explosion : MonoBehaviour
    {
        
        public void DestroySelf_U()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}

