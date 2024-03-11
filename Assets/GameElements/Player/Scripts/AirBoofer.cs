using System;
using UnityEngine;

namespace Platformer.Units.PlayerSpace
{
    public class AirBoofer : MonoBehaviour
    {
        public event Action TouchGround;
        public event Action LeaveGround;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            TouchGround?.Invoke();
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            LeaveGround?.Invoke();
        }
    }
}

