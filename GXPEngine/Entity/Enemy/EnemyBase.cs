using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine.Enemy
{
    abstract class EnemyBase : AnimationSprite
    {
        public EnemyBase(string filename, int cols, int rows, int frames = -1) : base(filename, cols, rows, frames)
        {

        }
    }
}
