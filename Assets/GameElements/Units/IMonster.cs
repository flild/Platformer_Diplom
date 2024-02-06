using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Units
{
    public interface IMonster
    {
        event EventHandler<IMonster> OnUnitDeathEvent;
        public Transform transform { get; }
        public void Death();
        public void TakeDamage(float value);
    }

}

