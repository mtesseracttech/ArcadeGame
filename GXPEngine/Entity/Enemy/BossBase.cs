using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Entity.Enemy
{
    class BossBase : AnimationSprite
    {
        protected int HealthPoints;
        protected int Damage;


        public BossBase(string filename, int cols, int rows, int frames = -1) : base(filename, cols, rows, frames)
        {
        }
    }
}
