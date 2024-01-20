using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    public class Stats : MonoBehaviour
    {
        //speed
        [Header("Speed"),Range(0,15)]
        public float speed;
        public float MaxSpeed;
        public float MinSpeed;
        //Health
        [Space, Header("Health"), Range(0, 10)]
        public float Health;
        public float MaxHealth;
        
        //Jump
        [Space, Header("Jump"), Range(0, 15)]
        public float JumpForce;
        //todo Luck
        private void Start()
        {
            MaxHealth = Health;
        }
    }


}

