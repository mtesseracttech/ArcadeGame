using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TimeGuardian.Level;

namespace TimeGuardian.Entity
{
    class DebugBall : AnimationSprite
    {
        private float _moveX, _moveY;
        private LevelBase _level;

        public DebugBall(LevelBase level) : base(UtilStrings.AnimSpriteDebug, 2, 1)
        {
            _level = level;
            SetXY(game.width, game.height);
            SetOrigin(width/2, height/2);
            _moveX = 1;
            _moveY = 1;
        }

        void Update()
        {
            if (!_level.GetPaused()) UpdateUnpaused();

        }

        void UpdateUnpaused()
        {
            if(!_level.GetTimeStopped()) UpdateNoTimeStop();
        }

        void UpdateNoTimeStop()
        {
            Move(_moveX, _moveY);
            Collision();
        }

        void Collision()
        {
            if (x > game.width || x < 0) _moveX = -_moveX;
            if (y > game.height || y < 0) _moveY = -_moveY;
        }
    }
}
