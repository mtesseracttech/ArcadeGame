using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Fireball : AnimationSprite
    {
        public Fireball(int x, int y) : base("../res/img/flame.png", 3, 2, 60)
        {
            this.x = x;
            this.y = y;
            scaleX = 0.5;
            scaleY = 0.5;
        }

        private int iterator = 0;
        void Update()
        {

        }
    }
}
