using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeGuardian.Entity.Enemy
{
    class BossBase : AnimationSprite
    {
        protected int HealthPoints;
        protected int Damage;
        protected bool Vurnerable; //Value is used to temporarily make the boss vurnerable to player attacks, boss is invincible otherwise.


        public BossBase(string filename, int cols, int rows, int frames = -1) : base(filename, cols, rows, frames)
        {
        }
    }
}
